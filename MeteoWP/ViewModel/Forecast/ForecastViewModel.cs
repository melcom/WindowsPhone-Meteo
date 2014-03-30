using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MeteoWP.Service.WeatherApiService;
using WeatherBackend.Api;

namespace MeteoWP.ViewModel.Forecast
{
    public class ForecastViewModel : NavigationViewModelBase, IForecastViewModel
    {
        private readonly IWeatherApiService weatherApiService;
        private IForecastWeather forecastWeather;

        public ForecastViewModel(IWeatherApiService weatherApiService)
        {
            this.weatherApiService = weatherApiService;
        }

        #region IForecastViewModel Members

        public IForecastWeather ForecastWeather
        {
            get { return forecastWeather; }
            set
            {
                forecastWeather = value;
                RaisePropertyChanged(() => ForecastWeather);
            }
        }

        #endregion

        protected override async Task LoadData(IDictionary<string, string> queryString)
        {
            string city = queryString["city"];

            try
            {
                ForecastWeather = await weatherApiService.CurrentApi.GetForecastWeather(city);
            }
            catch (Exception)
            {
            }
        }
    }
}