using Member.Application.Contracts.Persistence;
using Member.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Member.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IMemberRepository, MemberRepository>();
            return services;
        }
    }
}
