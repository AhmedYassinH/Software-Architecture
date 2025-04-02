
using DoctorBooking.DoctorAvailability.DAL.EFStructures;
using DoctorBooking.DoctorAvailability.DAL.Initializer;
using DoctorBooking.DoctorAvailability.DAL.Repos;
using DoctorBooking.DoctorAvailability.Services;
using DoctorBooking.Shared.Modules;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Text.Json.Serialization;

namespace DoctorBooking.DoctorAvailability
{
    public class DoctorAvailabilityModule : IModule
    {
        public void MapEndpoints(IEndpointRouteBuilder builder)
        {
            builder.MapControllers();
        }

        public void Initialize(WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<AvailabilityDbContext>();
            Initializer.InitializeData(dbContext);
        }

        public void RegisterServices(IServiceCollection services)
        {
            services
           .AddControllers(config =>
           {
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
            services.AddDbContext<AvailabilityDbContext>(o => o.UseInMemoryDatabase("DoctorAvailability"));
            services.AddScoped<DoctorSlotRepo>();
            services.AddScoped<DoctorSlotService>();


        }
    }
}
