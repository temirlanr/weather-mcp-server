using WeatherMcpServer.Domain.Dtos;

namespace WeatherMcpServer.Application.Contracts
{
    public interface IWeatherService
    {
        Task<GetCurrentWeatherResponse?> GetCurrentWeatherAsync(string city);
    }
}
