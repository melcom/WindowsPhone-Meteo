using System.Windows;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using MeteoWP.Message;
using MeteoWP.Resources;
using MeteoWP.Service.SettingsService;
using WeatherBackend;
using WeatherBackend.Api;

namespace MeteoWP.Service.WeatherApiService
{
    public class WeatherApiService : IWeatherApiService
    {
        private readonly ISettingsService settingsService;
        private IWeatherApi api;

        public WeatherApiService(ISettingsService settingsService)
        {
            this.settingsService = settingsService;
        }

        #region Implementation of IRssApiService

        public IWeatherApi CurrentApi
        {
            get
            {
                if (string.IsNullOrEmpty(settingsService.City))
                {
                    MessageBox.Show(AppResources.ConfigureCity);
                    Messenger.Default.Send(new GlobalNavigationMessage(ViewList.Settings));
                    return null;
                }

                api = new WeatherApi();
                return api;
            }
        }

        #endregion
    }
}