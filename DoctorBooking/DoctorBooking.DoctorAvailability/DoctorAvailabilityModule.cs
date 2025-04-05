
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
            throw new NotImplementedException();
        }

        public void Initialize(WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<AvailabilityDbContext>();
            Initializer.InitializeData(dbContext);
        }

        public void RegisterServices(IServiceCollection services)
        {
            
            services.AddDbContext<AvailabilityDbContext>(o => o.UseInMemoryDatabase("DoctorAvailability"));
            services.AddScoped<DoctorSlotRepo>();
            services.AddScoped<DoctorSlotService>();


        }
    }
}
