using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using MeteoWP.Message;
using MeteoWP.Service.SettingsService;

namespace MeteoWP.ViewModel.Settings
{
    public class SettingsViewModel : NavigationViewModelBase, ISettingsViewModel
    {
        private readonly ISettingsService settingsService;
        private string city;

        public SettingsViewModel(ISettingsService settingsService)
        {
            this.settingsService = settingsService;
        }

        #region Implementation of ISettingsViewModel

        public string City
        {
            get { return settingsService.City; }
            set
            {
                settingsService.City = value;
                RaisePropertyChanged(() => City);
            }
        }

        #endregion
    }
}