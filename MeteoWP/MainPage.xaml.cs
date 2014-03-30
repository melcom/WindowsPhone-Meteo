using System;
using GalaSoft.MvvmLight.Messaging;
using MeteoWP.Message;
using MeteoWP.Resources;
using MeteoWP.View;
using Microsoft.Phone.Shell;

namespace MeteoWP
{
    public partial class MainPage : ViewBase
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            Messenger.Default.Register<GlobalNavigationMessage>(this, message => NavigationService.Navigate(message.ViewUri));

            //Build ApplicationBar
            ApplicationBar = new ApplicationBar();

            var refresh = new ApplicationBarIconButton(new Uri("/Icons/appbar.refresh.png", UriKind.Relative));
            refresh.Text = AppResources.Refresh;
            refresh.Click += RefreshClick;
            ApplicationBar.Buttons.Add(refresh);
            var settings = new ApplicationBarIconButton(new Uri("/Icons/appbar.settings.png", UriKind.Relative));
            settings.Text = AppResources.Settings;
            settings.Click += SettingsClick;
            ApplicationBar.Buttons.Add(settings);
        }

        private void RefreshClick(object sender, EventArgs e)
        {
            Refresh();
        }

        private void SettingsClick(object sender, EventArgs e)
        {
            Messenger.Default.Send(new GlobalNavigationMessage(ViewList.Settings));
        }
    }
}