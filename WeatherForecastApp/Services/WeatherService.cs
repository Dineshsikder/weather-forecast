// WeatherService.cs

using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WeatherForecastApp.Exceptions;
using Microsoft.Extensions.Logging;

namespace WeatherForecastApp.Services 
{
    public class WeatherService : IWeatherService
    {
        // private readonly HttpClient _httpClient;

        // public WeatherService(HttpClient httpClient)
        // {
        //     _httpClient = httpClient;
        // }
        private readonly ILogger<WeatherService> _logger;
        private readonly IHttpClientFactory _httpClientFactory;

        public WeatherService(IHttpClientFactory httpClientFactory, ILogger<WeatherService> logger)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }

        public async Task<string> GetWeatherForecast(String latitude, String longitude, String current, String hourly, String daily, String start_date,
        string end_date, string timezone, string temperature_unit)
        {
            try
            {
                var apiUrl = $"https://api.open-meteo.com/v1/forecast?latitude={latitude}&longitude={longitude}";
                if (current != null && current.Length != 0)
                {
                    apiUrl = $"{apiUrl}&current={string.Join(",", current)}";
                }
                if (hourly != null && hourly.Length != 0)
                {
                    apiUrl = $"{apiUrl}&hourly={string.Join(",", hourly)}";
                }
                if (daily != null && daily.Length != 0)
                {
                    apiUrl = $"{apiUrl}&daily={string.Join(",", daily)}";
                }
                if (!string.IsNullOrEmpty(start_date))
                {
                    apiUrl = $"{apiUrl}&start_date={start_date}";
                }
                if (!string.IsNullOrEmpty(end_date))
                {
                    apiUrl = $"{apiUrl}&end_date={end_date}";
                }
                if (!string.IsNullOrEmpty(timezone))
                {
                    apiUrl = $"{apiUrl}&timezone={timezone}";
                }
                if (!string.IsNullOrEmpty(temperature_unit))
                {
                    apiUrl = $"{apiUrl}&temperature_unit={temperature_unit}";
                }

                // Make the HTTP request
                var response = await _httpClientFactory.CreateClient().GetStringAsync(apiUrl);
                _logger.LogInformation("response",response);
                // Parse the JSON response and return the weather forecast
                // Use a library like System.Text.Json or Newtonsoft.Json for JSON deserialization
                // var weatherForecast = ParseResponse(response);

                return response;
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Failed to fetch weather data: {ex.Message}", ex);
                // Handle exceptions appropriately
                throw new WeatherServiceException($"Failed to fetch weather data: {ex.Message}", ex);
            }
        }

        // private WeatherForecast ParseResponse(string jsonResponse)
        // {
        //     // Implement the logic to parse the JSON response and create a WeatherForecast object
        //     // Example using System.Text.Json:
        //     var weatherForecast = JsonSerializer.Deserialize<WeatherForecast>(jsonResponse);

        //     // Example using Newtonsoft.Json:
        //     // var weatherForecast = JsonConvert.DeserializeObject<WeatherForecast>(jsonResponse);

        //     // Return the parsed WeatherForecast object
        //     // Ensure that your WeatherForecast class matches the structure of the JSON response
        //     return weatherForecast;
        // }
    }
}


