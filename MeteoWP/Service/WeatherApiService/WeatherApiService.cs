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
        private IWeatherApi api;

        #region Implementation of IRssApiService

        public IWeatherApi CurrentApi
        {
            get
            {
                var settings = SimpleIoc.Default.GetInstance<ISettingsService>();

                if (string.IsNullOrEmpty(settings.City))
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