using DoctorBooking.Host;
using DoctorBooking.Shared.Core;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IEventBus, EventBus>();
builder.Services.AddModules();


var app = builder.Build();



app.UseHttpsRedirection();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapModuleEndpoints();
app.Run();

