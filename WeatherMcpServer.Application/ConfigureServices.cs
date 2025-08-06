using Microsoft.Extensions.DependencyInjection;
using WeatherMcpServer.Application.Contracts;
using WeatherMcpServer.Application.Services;

namespace WeatherMcpServer.Application
{
    public static class ConfigureServices
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IWeatherService, WeatherService>();
        }
    }
}
