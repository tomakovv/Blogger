using Domain.Interfaces;
using Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
           
            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<ICosmosPostRepository, CosmosPostRepository>();
            return services;
        }
    }
}
