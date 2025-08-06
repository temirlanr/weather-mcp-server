using WeatherMcpServer.Application.Dtos;

namespace WeatherMcpServer.Application.Contracts
{
    public interface IWeatherService
    {
        Task<GetCurrentWeatherResponse?> GetCurrentWeatherAsync(string city);
        Task<GetForecastResponse?> GetForecastAsync(string city);
    }
}
