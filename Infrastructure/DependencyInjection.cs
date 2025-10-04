using Application.Interfaces;
using Infrastructure.Services.BaseService;
using Infrastructure.Services.TokenProviderServices;
using Infrastructure.Services.UserServices;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services)
        {
            var assembly = typeof(DependencyInjection).Assembly;

            services.AddScoped<IBaseService, BaseService>();
            services.AddScoped<ITokenProvider, TokenProvider>();
            services.AddScoped<IUserService, UserService>();

            return services;
        }
    }
}
