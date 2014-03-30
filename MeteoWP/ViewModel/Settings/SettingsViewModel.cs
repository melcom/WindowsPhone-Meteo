using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using MeteoWP.Message;
using MeteoWP.Service.SettingsService;

namespace MeteoWP.ViewModel.Settings
{
    public class SettingsViewModel : NavigationViewModelBase, ISettingsViewModel
    {
        private string city;

        public SettingsViewModel()
        {
            var settings = SimpleIoc.Default.GetInstance<ISettingsService>();

            City = settings.City;

            Messenger.Default.Register<SaveSettingsMessage>(this, s =>
            {
                settings.City = City;
                Messenger.Default.Send(new GlobalNavigationMessage(ViewList.MainPage));
            });
        }

        #region Implementation of ISettingsViewModel

        public string City
        {
            get { return city; }
            set
            {
                city = value;
                RaisePropertyChanged(() => City);
            }
        }

        #endregion
    }
}