using System.ComponentModel;

namespace WeatherMcpServer.Application.Dtos
{
    public class GetForecastDto
    {
        [Description("City name (required). Example: \"Astana\" or \"Astana,KZ\"")]
        public string City { get; set; } = null!;
        [Description("Hours ahead to forecast (required). Use values like 3, 6, 9, 12, 15, etc.")]
        public int Hours { get; set; } = 72;
    }
}
