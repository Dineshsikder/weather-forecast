// Models/WeatherForecast.cs
namespace WeatherForecastApp.Model 
{

    public class WeatherForecastRequest
    {
        public string start_date { get; set; }
        public string end_date { get; set; }
        public string[] daily { get; set; }
        public string[] hourly { get; set; }
        public string[] current { get; set; }
        public string latitude { get; set; }
        public int past_days { get; set; }
        public string longitude { get; set; }
        public string timezone { get; set; }
        public string timezone_abbreviation { get; set; }
        public string generationtime_ms { get; set; }

        public override string ToString()
        {
            return string.Format("WeatherForecastRequest: {0}, {1}, {2}", longitude, latitude, hourly);   
            // Where Nome, Cognome and Number are variables in Persona class
        }
    }
}
