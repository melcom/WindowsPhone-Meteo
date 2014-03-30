using WeatherBackend.Api;

namespace MeteoWP.Service.WeatherApiService
{
    public interface IWeatherApiService
    {
        IWeatherApi CurrentApi { get; }
    }
}