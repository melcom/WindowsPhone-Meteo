using Newtonsoft.Json;

namespace WeatherBackend.Json
{
    internal class Clouds
    {
        [JsonProperty("all")]
        public int All { get; set; }
    }
}