using Member.Application;
using Member.Infrastructure;
namespace Member.API.ExtensionMethod
{
    public static class APIServiceRegistrations
    {
        public static IServiceCollection AddAPIServiceRegistration(this IServiceCollection services)
        {
            services.AddApplicationServices();
            services.AddInfrastructureServices();
            services.AddEndpointsApiExplorer();
            return services;
        }
    }
}
