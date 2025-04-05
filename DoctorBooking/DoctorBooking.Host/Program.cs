using DoctorBooking.Host;
using DoctorBooking.Host.Filters;
using DoctorBooking.Shared.Core;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IEventBus, EventBus>();
builder.Services.AddAppLogger();

builder.Services.AddControllers(config =>
           {
               config.Filters.Add(typeof(CustomExceptionFilter));
               config.SuppressAsyncSuffixInActionNames = false;
           })
           .AddJsonOptions(options =>
           {
               options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
               options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
               options.JsonSerializerOptions.AllowTrailingCommas = true;
               options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;

           })
           .ConfigureApiBehaviorOptions(options =>
           {
               options.SuppressModelStateInvalidFilter = true;
               options.SuppressMapClientErrors = false;
               options.ClientErrorMapping[StatusCodes.Status404NotFound].Link = "https://httpstatuses.com/404";
               options.ClientErrorMapping[StatusCodes.Status404NotFound].Title = "Invalid location";
           });

builder.Services.AddModules();



var app = builder.Build();

app.UseHttpsRedirection();

if (app.Environment.IsDevelopment())
{
    app.InitializeModules();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.MapGet("/", () => "Modular Monolith listening");
app.Run();

