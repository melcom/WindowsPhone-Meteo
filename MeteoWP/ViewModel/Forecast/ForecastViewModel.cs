using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Ioc;
using MeteoWP.Service.WeatherApiService;
using WeatherBackend.Api;

namespace MeteoWP.ViewModel.Forecast
{
    public class ForecastViewModel : NavigationViewModelBase, IForecastViewModel
    {
        private IForecastWeather forecastWeather;

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

            IWeatherApi api = SimpleIoc.Default.GetInstance<IWeatherApiService>().CurrentApi;
            try
            {
                ForecastWeather = await api.GetForecastWeather(city);
            }
            catch (Exception)
            {
            }
        }
    }
}