using System.Collections.Generic;

namespace WeatherBackend.Api
{
    public class ForecastWeather : IForecastWeather
    {
        #region Implementation of IForecastWeather

        public List<DisplayWeather> ForecastList { get; set; }

        #endregion
    }
}