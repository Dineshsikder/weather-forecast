// IWeatherService.cs

using System.Threading.Tasks;
namespace WeatherForecastApp.Services
{
    public interface IWeatherService
    {
        Task<string> GetWeatherForecast(String latitude, String longitude, String current, String hourly, String daily, String start_date,
        string end_date, string timezone, string temperature_unit);
    }
}

