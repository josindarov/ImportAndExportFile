using Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class Startup
    {
        public static IServiceCollection AddApplicationDependencies(this IServiceCollection services)
        {
            services.AddScoped<FileService>();
            return services;
        }
    }
}
