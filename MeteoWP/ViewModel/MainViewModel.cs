using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using MeteoWP.Message;
using MeteoWP.Service.SettingsService;
using MeteoWP.Service.WeatherApiService;
using WeatherBackend.Api;

namespace MeteoWP.ViewModel
{
    public class MainViewModel : NavigationViewModelBase
    {
        private string currentCity;
        private IDisplayWeather displayWeather;

        public MainViewModel()
        {
            ForecastCommand = new RelayCommand(() => Messenger.Default.Send(new GlobalNavigationMessage(ViewList.Previsions, new List<UriParameter>
            {
                new UriParameter("city", currentCity)
            })));
        }

        #region Overrides of NavigationViewModelBase

        protected override async Task LoadData(IDictionary<string, string> queryString)
        {
            IWeatherApi api = SimpleIoc.Default.GetInstance<IWeatherApiService>().CurrentApi;
            var settings = SimpleIoc.Default.GetInstance<ISettingsService>();
            try
            {
                if (!string.IsNullOrEmpty(settings.City))
                {
                    currentCity = settings.City;
                    DisplayWeather = await api.GetCurrentWeather(settings.City);
                }
            }
            catch (Exception)
            {
            }
        }

        #endregion

        public IDisplayWeather DisplayWeather
        {
            get { return displayWeather; }
            set
            {
                displayWeather = value;
                RaisePropertyChanged(() => DisplayWeather);
            }
        }

        public ICommand ForecastCommand { get; set; }
    }
}