using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Builder;
namespace DoctorBooking.Shared.Modules
{
    public interface IModule
    {
        void RegisterServices(IServiceCollection services);
        void MapEndpoints(IEndpointRouteBuilder builder);
        void Initialize(WebApplication app);
    }
}
