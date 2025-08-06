namespace WeatherMcpServer.Application.Dtos
{
    public class GetCurrentWeatherResponse
    {
        public GetWeatherMain Main { get; set; } = null!;
        public GetWeatherWeather[] Weather { get; set; } = [];
        public string Name { get; set; } = null!;
    }
}
