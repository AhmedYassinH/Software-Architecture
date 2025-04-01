using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Routing;
namespace DoctorBooking.Shared.Modules
{
    public interface IModule
    {
        void RegisterServices(IServiceCollection services);
        void MapEndpoints(IEndpointRouteBuilder endpoints);
        Task InitializeAsync();
    }
}
