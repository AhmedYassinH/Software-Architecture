

using Microsoft.Extensions.DependencyInjection;

namespace DoctorBooking.Shared.Core
{
    public static class LoggerConfiguration
    {
        public static IServiceCollection AddAppLogger(this IServiceCollection services)
        {
            return services.AddScoped(typeof(IAppLogger<>), typeof(AppLogger<>));
        }
    }
}
