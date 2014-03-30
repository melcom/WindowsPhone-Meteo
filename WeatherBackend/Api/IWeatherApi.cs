using System.Threading.Tasks;

namespace WeatherBackend.Api
{
    public interface IWeatherApi
    {
        Task<IDisplayWeather> GetCurrentWeather(string city);
        Task<IForecastWeather> GetForecastWeather(string city);
    }
}