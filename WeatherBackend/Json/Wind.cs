using Newtonsoft.Json;

namespace WeatherBackend.Json
{
    internal class Wind
    {
        [JsonProperty("speed")]
        public double Speed { get; set; }

        [JsonProperty("deg")]
        public double Deg { get; set; }
    }
}