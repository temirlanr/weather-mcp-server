using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using System.Net.Http.Json;
using WeatherMcpServer.Application.Contracts;
using WeatherMcpServer.Domain.Dtos;

namespace WeatherMcpServer.Application.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly ILogger<WeatherService> _logger;
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;
        private const string BaseUrl = "https://api.openweathermap.org/data/2.5/weather";

        public WeatherService(IConfiguration configuration, ILogger<WeatherService> logger)
        {
            _logger = logger;
            _httpClient = new HttpClient();
            _apiKey = configuration["OpenWeather:ApiKey"] 
                ?? throw new ArgumentNullException("OpenWeather:ApiKey not found in configuration");
        }

        public async Task<GetCurrentWeatherResponse?> GetCurrentWeatherAsync(string city)
        {
            var url = $"{BaseUrl}?q={city}&appid={_apiKey}&units=metric";

            var response = await _httpClient.GetAsync(url);
            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError($"Failed to fetch weather data: {response.StatusCode}");
                return null;
            }

            var weatherData = await response.Content.ReadFromJsonAsync<GetCurrentWeatherResponse>();

            return weatherData;
        }
    }
}
