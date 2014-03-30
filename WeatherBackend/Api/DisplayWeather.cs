namespace WeatherBackend.Api
{
    public class DisplayWeather : IDisplayWeather
    {
        #region Implementation of IDisplayWeather

        public string Name { get; set; }
        public string Temp { get; set; }
        public string TempMax { get; set; }
        public string TempMin { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
        public string Date { get; set; }

        #endregion
    }
}