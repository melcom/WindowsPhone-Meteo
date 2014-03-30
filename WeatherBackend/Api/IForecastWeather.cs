using System.Collections.Generic;

namespace WeatherBackend.Api
{
    public interface IForecastWeather
    {
        List<DisplayWeather> ForecastList { get; set; }
    }
}