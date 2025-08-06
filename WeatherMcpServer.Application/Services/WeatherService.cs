using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using System.Net.Http.Json;
using WeatherMcpServer.Application.Contracts;
using WeatherMcpServer.Application.Dtos;

namespace WeatherMcpServer.Application.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly ILogger<WeatherService> _logger;
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;
        private const string WeatherUrl = "https://api.openweathermap.org/data/2.5/weather";
        private const string ForecastUrl = "https://api.openweathermap.org/data/2.5/forecast";

        public WeatherService(IConfiguration configuration, ILogger<WeatherService> logger)
        {
            _logger = logger;
            _httpClient = new HttpClient();
            _apiKey = configuration["OpenWeather:ApiKey"]
                ?? throw new ArgumentNullException("OpenWeather:ApiKey not found in configuration");
        }

        public async Task<GetCurrentWeatherResponse?> GetCurrentWeatherAsync(string city)
        {
            var url = $"{WeatherUrl}?q={city}&appid={_apiKey}&units=metric";

            var response = await _httpClient.GetAsync(url);
            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError($"Failed to fetch weather data: {response.StatusCode}");
                throw new ArgumentException(response.StatusCode.ToString());
            }

            var weatherData = await response.Content.ReadFromJsonAsync<GetCurrentWeatherResponse>();

            return weatherData;
        }

        public async Task<GetForecastResponse?> GetForecastAsync(string city)
        {
            var url = $"{ForecastUrl}?q={city}&appid={_apiKey}";

            var response = await _httpClient.GetAsync(url);
            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError($"Failed to fetch daily forecast data: {response.StatusCode}");
                throw new ArgumentException(response.StatusCode.ToString());
            }

            var forecastData = await response.Content.ReadFromJsonAsync<GetForecastResponse>();

            return forecastData;
        }
    }
}
