// Models/WeatherForecast.cs
namespace WeatherForecastApp.Model {

public class WeatherForecast
{
    public DateTime Date { get; set; }
    public double HighTemperature { get; set; }
    public double LowTemperature { get; set; }
    public double HighApparentTemperature { get; set; }
    public double LowApparentTemperature { get; set; }
    public int AverageRelativeHumidity { get; set; }
    public double PrecipitationProbability { get; set; }
    public double Precipitation { get; set; }
}
}
