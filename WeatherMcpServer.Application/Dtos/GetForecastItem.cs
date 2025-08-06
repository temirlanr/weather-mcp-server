namespace WeatherMcpServer.Application.Dtos
{
    public class GetForecastItem
    {
        public long Dt { get; set; }
        public GetWeatherMain Main { get; set; } = null!;
        public GetWeatherWeather[] Weather { get; set; } = [];
        public string Dt_txt { get; set; } = null!;
    }
}
