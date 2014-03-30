using System;
using MeteoWP.Resources;
using Microsoft.Phone.Shell;

namespace MeteoWP.View
{
    public partial class PrevisionView : ViewBase
    {
        public PrevisionView()
        {
            InitializeComponent();

            //Build ApplicationBar
            ApplicationBar = new ApplicationBar();

            var refresh = new ApplicationBarIconButton(new Uri("/Icons/appbar.refresh.png", UriKind.Relative));
            refresh.Text = AppResources.Refresh;
            refresh.Click += RefreshClick;
            ApplicationBar.Buttons.Add(refresh);
        }

        private void RefreshClick(object sender, EventArgs e)
        {
            Refresh();
        }
    }
}