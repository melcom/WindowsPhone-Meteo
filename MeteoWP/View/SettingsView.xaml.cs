using System;
using GalaSoft.MvvmLight.Messaging;
using MeteoWP.Message;
using MeteoWP.Resources;
using Microsoft.Phone.Shell;

namespace MeteoWP.View
{
    public partial class Settings : ViewBase
    {
        public Settings()
        {
            InitializeComponent();

            //Build ApplicationBar
            ApplicationBar = new ApplicationBar();

            var refresh = new ApplicationBarIconButton(new Uri("/Icons/appbar.save.png", UriKind.Relative));
            refresh.Text = AppResources.Save;
            refresh.Click += SaveClick;
            ApplicationBar.Buttons.Add(refresh);
        }

        private void SaveClick(object sender, EventArgs e)
        {
            //Force binding refresh
            UpdateBinding();
            Messenger.Default.Send(new SaveSettingsMessage());
        }
    }
}