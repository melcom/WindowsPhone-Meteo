using WeatherBackend.Api;

namespace MeteoWP.ViewModel.Forecast
{
    public interface IForecastViewModel
    {
        IForecastWeather ForecastWeather { get; set; }
    }
}