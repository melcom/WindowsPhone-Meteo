using Newtonsoft.Json;

namespace WeatherBackend.Json
{
    internal class Rain
    {
        [JsonProperty("3h")]
        public string ThreeH { get; set; }
    }
}