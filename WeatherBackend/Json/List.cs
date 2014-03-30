using Newtonsoft.Json;

namespace WeatherBackend.Json
{
    internal class List
    {
        [JsonProperty("dt")]
        public int Dt { get; set; }

        [JsonProperty("main")]
        public Main Main { get; set; }

        [JsonProperty("weather")]
        public Weather[] Weather { get; set; }

        [JsonProperty("clouds")]
        public Clouds Clouds { get; set; }

        [JsonProperty("wind")]
        public Wind Wind { get; set; }

        [JsonProperty("rain")]
        public Rain Rain { get; set; }

        [JsonProperty("sys")]
        public Sys2 Sys { get; set; }

        [JsonProperty("dt_txt")]
        public string DtTxt { get; set; }
    }
}