using System.IO.IsolatedStorage;
using GalaSoft.MvvmLight.Messaging;
using MeteoWP.Message;

namespace MeteoWP.Service.SettingsService
{
    public class SettingsService : ISettingsService
    {
        private readonly Setting<string> citySetting;

        /// <summary>
        ///     Initialise une nouvelle instance de la classe <see cref="T:System.Object" />.
        /// </summary>
        public SettingsService()
        {
            IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;

            citySetting = new Setting<string>(settings, "City", string.Empty, false);

            Messenger.Default.Register<SaveSettingsMessage>(this, s =>
            {
                settings.Save();
                Messenger.Default.Send(new GlobalNavigationMessage(ViewList.MainPage));
            });
        }

        #region ISettingsService Members

        public string City
        {
            get { return citySetting.Value; }
            set { citySetting.Value = value; }
        }

        #endregion
    }
}