using System.ComponentModel;
using ModelContextProtocol.Server;
using WeatherMcpServer.Application.Contracts;

namespace WeatherMcpServer.Tools;

public class WeatherTools(IWeatherService weatherService)
{
    [McpServerTool(Name = "current_weather")]
    [Description("Describes weather in the provided city.")]
    public async Task<string> GetCityWeatherAsync(
        [Description("City to return weather for")] string city)
    {
        try
        {
            var weather = await weatherService.GetCurrentWeatherAsync(city);

            if (weather == null)
            {
                return $"Weather data for '{city}' not found.";
            }

            var cityInfo = $"Temperature: {weather.Main.Temp - 273.15}�C\n" +
                        $"Feels Like: {weather.Main.Feels_like - 273.15}�C\n" +
                        $"Humidity: {weather.Main.Humidity}%\n" +
                        $"Description: {string.Join(',', weather.Weather.Select(x => x.Description))}";

            return cityInfo;
        }
        catch (Exception ex)
        {
            return $"Error fetching weather for '{city}': {ex.Message}";
        }
    }

    [McpServerTool(Name = "forecast_weather")]
    [Description("Get weather forecast for a city after 72 hours.")]
    public async Task<string> GetCityForecastAsync(
        [Description("City to return forecast for. Also specify hours ahead.")] string city)
    {
        try
        {
            var forecast = await weatherService.GetForecastAsync(city);
            if (forecast == null)
            {
                return $"Forecast data for '{city}' not found.";
            }

            var index = 25; // Couldn't find a way to pass hours ahead, so using 25 as default
            var item = forecast.List.ElementAtOrDefault(index)
                ?? throw new ArgumentException("Out of time range");

            var forecastInfo =
                    $"Date: {item.Dt_txt}\n" +
                    $"Temperature: {item.Main.Temp - 273.15}�C\n" +
                    $"Feels like: {item.Main.Feels_like - 273.15}�C\n" +
                    $"Humidity: {item.Main.Humidity}%\n" +
                    $"Description: {string.Join(',', item.Weather.Select(x => x.Description))}";

            return forecastInfo;
        }
        catch(Exception ex)
        {
            return $"Error fetching forecast for '{city}': {ex.Message}";
        }
    }
}