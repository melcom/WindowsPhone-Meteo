using Newtonsoft.Json;

namespace WeatherBackend.Json
{
    internal class Sys2
    {
        [JsonProperty("pod")]
        public string Pod { get; set; }
    }
}