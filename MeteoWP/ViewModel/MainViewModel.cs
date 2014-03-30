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
        private readonly IWeatherApiService weatherApiService;
        private readonly ISettingsService settingsService;
        private string currentCity;
        private IDisplayWeather displayWeather;

        public MainViewModel(IWeatherApiService weatherApiService, ISettingsService settingsService)
        {
            this.weatherApiService = weatherApiService;
            this.settingsService = settingsService;
            ForecastCommand = new RelayCommand(() => Messenger.Default.Send(new GlobalNavigationMessage(ViewList.Previsions, new List<UriParameter>
            {
                new UriParameter("city", currentCity)
            })));
        }

        #region Overrides of NavigationViewModelBase

        protected override async Task LoadData(IDictionary<string, string> queryString)
        {
            try
            {
                if (!string.IsNullOrEmpty(settingsService.City))
                {
                    currentCity = settingsService.City;
                    DisplayWeather = await weatherApiService.CurrentApi.GetCurrentWeather(currentCity);
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