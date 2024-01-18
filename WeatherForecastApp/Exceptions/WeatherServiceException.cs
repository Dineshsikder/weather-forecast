// WeatherServiceException.cs

using System;

namespace WeatherForecastApp.Exceptions
{
    public class WeatherServiceException : Exception
    {
        public WeatherServiceException()
        {
        }

        public WeatherServiceException(string message)
            : base(message)
        {
        }

        public WeatherServiceException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}

