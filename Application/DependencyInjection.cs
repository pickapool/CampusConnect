using Microsoft.Extensions.DependencyInjection;
namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
        {
            var assembly = typeof(DependencyInjection).Assembly;


            return services;
        }
    }
}
