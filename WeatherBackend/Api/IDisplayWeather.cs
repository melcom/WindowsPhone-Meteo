namespace WeatherBackend.Api
{
    public interface IDisplayWeather
    {
        string Date { get; set; }
        string Name { get; set; }
        string Temp { get; set; }
        string TempMax { get; set; }
        string TempMin { get; set; }
        string Description { get; set; }
        string Icon { get; set; }
    }
}