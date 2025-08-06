namespace WeatherMcpServer.Domain.Dtos
{
    public class GetCurrentWeatherResponse
    {
        public GetCurrentWeatherMain Main { get; set; } = null!;
        public GetCurrentWeatherWeather[] Weather { get; set; } = null!;
        public string Name { get; set; } = null!;
    }
}
