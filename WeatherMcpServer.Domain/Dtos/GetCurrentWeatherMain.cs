namespace WeatherMcpServer.Domain.Dtos
{
    public class GetCurrentWeatherMain
    {
        public float Temp { get; set; }
        public float Feels_like { get; set; }
        public int Humidity { get; set; }
    }
}
