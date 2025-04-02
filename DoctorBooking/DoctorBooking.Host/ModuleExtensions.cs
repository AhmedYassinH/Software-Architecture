using DoctorBooking.DoctorAvailability;
using DoctorBooking.Shared.Modules;

namespace DoctorBooking.Host
{
    public static class ModuleExtensions
    {
        private static readonly List<IModule> _modules = new(){
            new DoctorAvailabilityModule()
        };
        public static IServiceCollection AddModules(this IServiceCollection services)
        {
            foreach (IModule module in _modules)
            {
                services.AddModule(module);

            }

            return services;
        }

        public static IServiceCollection AddModule(this IServiceCollection services, IModule module)
        {
            module.RegisterServices(services);
            return services;
        }


        public static IApplicationBuilder MapModuleEndpoints(this WebApplication app, RouteGroupBuilder? routeGroupBuilder = null)
        {
            IEndpointRouteBuilder builder = routeGroupBuilder is null ? app : routeGroupBuilder;

            foreach (IModule module in _modules)
            {
                module.MapEndpoints(builder);
            }

            return app;
        }


        public static IApplicationBuilder InizializeModules(this WebApplication app)
        {

            foreach (IModule module in _modules)
            {
                module.Initialize(app);
            }


            return app;
        }
    }
}
