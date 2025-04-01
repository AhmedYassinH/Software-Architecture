using DoctorBooking.Shared.Modules;

namespace DoctorBooking.Host
{
    public static class ModuleExtensions
    {
        public static IServiceCollection AddModules(this IServiceCollection services)
        {
            //services.AddModule(IModule);

            return services;
        }

        public static IServiceCollection AddModule(this IServiceCollection services, IModule module)
        {
            module.RegisterServices(services);
            return services;
        }


        public static IApplicationBuilder MapModuleEndpoints(this WebApplication app, RouteGroupBuilder? routeGroupBuilder = null)
        {
            IEnumerable<IModule> endpoints = app.Services.GetRequiredService<IEnumerable<IModule>>();
            IEndpointRouteBuilder builder = routeGroupBuilder is null ? app : routeGroupBuilder;

            foreach (IModule endpoint in endpoints)
            {
                endpoint.MapEndpoints(builder);
            }

            return app;
        }
    }
}
