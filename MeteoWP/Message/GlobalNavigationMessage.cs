using System;
using System.Collections.Generic;
using System.Text;

namespace MeteoWP.Message
{
    public class GlobalNavigationMessage
    {
        private readonly List<UriParameter> parameters;
        private readonly ViewList viewList;

        public GlobalNavigationMessage(ViewList view)
        {
            viewList = view;
        }

        public GlobalNavigationMessage(ViewList view, List<UriParameter> parameters) : this(view)
        {
            this.parameters = parameters;
        }

        public Uri ViewUri
        {
            get
            {
                var uri = new StringBuilder();

                switch (viewList)
                {
                    case ViewList.Previsions:
                        uri.Append("/View/ForecastView.xaml");
                        break;
                    case ViewList.Settings:
                        uri.Append("/View/SettingsView.xaml");
                        break;
                    case ViewList.MainPage:
                        uri.Append("/MainPage.xaml");
                        break;
                }

                if (parameters != null && parameters.Count != 0)
                {
                    uri.Append("?");
                    bool first = true;
                    foreach (UriParameter parameter in parameters)
                    {
                        if (!first)
                            uri.Append("&");
                        first = false;
                        uri.AppendFormat("{0}={1}", parameter.Name, parameter.Value);
                    }
                }
                return new Uri(uri.ToString(), UriKind.Relative);
            }
        }
    }
}