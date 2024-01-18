using Microsoft.AspNetCore.Mvc;
using WeatherForecastApp.Services;
using Microsoft.Extensions.Logging;
using WeatherForecastApp.Model;

namespace WeatherForecastApp.Controllers
{
    [ApiController]
    [Route("api/weatherforecast")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IWeatherService _weatherService;
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(IWeatherService weatherService, ILogger<WeatherForecastController> logger)
        {
            _weatherService = weatherService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetWeatherForecast([FromQuery] String latitude, [FromQuery] String longitude, [FromQuery] String? current,
        [FromQuery] String? hourly, [FromQuery] String? daily, [FromQuery] String? start_date, [FromQuery] String? end_date, [FromQuery] String? timezone, [FromQuery] String? temperature_unit)
        {
            try
            {
                // WeatherForecastRequest requestBody = new WeatherForecastRequest
                // {
                //     start_date = start_date,
                //     end_date = end_date,
                //     daily = convertStringToArray(daily),
                //     hourly = convertStringToArray(hourly),
                //     current = convertStringToArray(current),
                //     latitude = latitude,
                //     longitude = longitude,
                //     timezone = timezone
                // };
                _logger.LogInformation("hour controller>>>>",hourly);
                var forecast = await _weatherService.GetWeatherForecast(latitude, longitude, current, hourly, daily, start_date, end_date, timezone, temperature_unit);
                return Ok(forecast);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        private String[] convertStringToArray(String param) {
            return !string.IsNullOrEmpty(param)
                ? param.Split(",")
                : Array.Empty<string>();
        }
    }
}



