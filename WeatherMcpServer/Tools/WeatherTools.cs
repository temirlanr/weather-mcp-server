using System.ComponentModel;
using ModelContextProtocol.Server;
using WeatherMcpServer.Application.Contracts;

namespace WeatherMcpServer.Tools;

public class WeatherTools(IWeatherService weatherService)
{
    [McpServerTool]
    [Description("Describes random weather in the provided city.")]
    public async Task<string> GetCityWeatherAsync(
        [Description("Name of the city to return weather for")] string city)
    {
        var weather = await weatherService.GetCurrentWeatherAsync(city);
        if( weather == null)
        {
            return $"Weather data for '{city}' not found.";
        }
        
        var result = $"Weather in {weather.Name}:\n" +
                    $"Temperature: {weather.Main.Temp}�C\n" +
                    $"Feels Like: {weather.Main.Feels_like}�C\n" +
                    $"Humidity: {weather.Main.Humidity}%\n" +
                    $"Description: {string.Join(',', weather.Weather.Select(x => x.Description))}";

        return result;
    }
}