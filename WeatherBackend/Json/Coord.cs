using Newtonsoft.Json;

namespace WeatherBackend.Json
{
    internal class Coord
    {
        [JsonProperty("lon")]
        public double Lon { get; set; }

        [JsonProperty("lat")]
        public double Lat { get; set; }
    }
}