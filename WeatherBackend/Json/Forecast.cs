using Newtonsoft.Json;

namespace WeatherBackend.Json
{
    internal class Forecast
    {
        [JsonProperty("cod")]
        public string Cod { get; set; }

        [JsonProperty("message")]
        public double Message { get; set; }

        [JsonProperty("city")]
        public City City { get; set; }

        [JsonProperty("cnt")]
        public int Cnt { get; set; }

        [JsonProperty("list")]
        public List[] List { get; set; }
    }
}