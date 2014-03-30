using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherBackend.Api;
using WeatherBackend.Json;

namespace WeatherBackend
{
    public class WeatherApi : IWeatherApi
    {
        private readonly string baseUri;

        public WeatherApi()
        {
            baseUri = "http://api.openweathermap.org/";
        }

        #region IWeatherApi Members

        public async Task<IDisplayWeather> GetCurrentWeather(string city)
        {
            using (var client = new HttpClientProvider(baseUri))
            {
                Current current = await client.Get<Current>(string.Format("data/2.5/weather?q={0},FR&units=metric&lang=fr", city));

                return new DisplayWeather
                {
                    Name = UpperFirst(current.Name),
                    Temp = string.Format("{0} °C", current.Main.Temp),
                    TempMax = string.Format("{0} °C", current.Main.TempMax),
                    TempMin = string.Format("{0} °C", current.Main.TempMin),
                    Description = UpperFirst(current.Weather[0].Description),
                    Icon = current.Weather[0].Icon
                };
            }
        }

        public async Task<IForecastWeather> GetForecastWeather(string city)
        {
            using (var client = new HttpClientProvider(baseUri))
            {
                Forecast forecast = await client.Get<Forecast>(string.Format("data/2.5/forecast?q={0},FR&units=metric&lang=fr", city));

                var forecastWeather = new ForecastWeather {ForecastList = new List<DisplayWeather>()};

                foreach (List list in forecast.List)
                {
                    forecastWeather.ForecastList.Add(new DisplayWeather
                    {
                        Temp = string.Format("{0} °C", list.Main.Temp),
                        TempMax = string.Format("{0} °C", list.Main.TempMax),
                        TempMin = string.Format("{0} °C", list.Main.TempMin),
                        Description = UpperFirst(list.Weather[0].Description),
                        Date = list.DtTxt,
                        Icon = list.Weather[0].Icon
                    });
                }

                return forecastWeather;
            }
        }

        #endregion

        private string UpperFirst(string input)
        {
            if (string.IsNullOrEmpty(input))
                return string.Empty;

            char[] array = input.ToCharArray();
            array[0] = char.ToUpper(array[0]);
            return new string(array);
        }
    }
}