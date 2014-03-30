using System;
using System.Globalization;
using System.Windows.Data;

namespace MeteoWP.Converter
{
    public class IconConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var icon = value as string;

            if (icon != null)
            {
                if (icon.Equals("01d", StringComparison.InvariantCultureIgnoreCase)) //sky is clear
                    return "/Icons/weezle_sun.png";
                if (icon.Equals("02d", StringComparison.InvariantCultureIgnoreCase)) // few clouds
                    return "/Icons/weezle_cloud_sun.png";
                if (icon.Equals("03d", StringComparison.InvariantCultureIgnoreCase)) //scattered clouds
                    return "/Icons/weezle_medium_cloud.png";
                if (icon.Equals("04d", StringComparison.InvariantCultureIgnoreCase)) // broken clouds
                    return "/Icons/weezle_max_cloud.png";
                if (icon.Equals("09d", StringComparison.InvariantCultureIgnoreCase)) // shower rain
                    return "/Icons/weezle_medium_rain.png";
                if (icon.Equals("10d", StringComparison.InvariantCultureIgnoreCase)) //Rain
                    return "/Icons/weezle_rain.png";
                if (icon.Equals("11d", StringComparison.InvariantCultureIgnoreCase)) //Thunderstorm
                    return "/Icons/weezle_cloud_thunder_rain.png";
                if (icon.Equals("13d", StringComparison.InvariantCultureIgnoreCase)) //snow
                    return "/Icons/weezle_snow.png";
                if (icon.Equals("50d", StringComparison.InvariantCultureIgnoreCase)) //mist 
                    return "/Icons/weezle_fog.png";

                if (icon.Equals("01n", StringComparison.InvariantCultureIgnoreCase)) //sky is clear
                    return "/Icons/weezle_fullmoon.png";
                if (icon.Equals("02n", StringComparison.InvariantCultureIgnoreCase)) //few clouds
                    return "/Icons/weezle_moon_cloud.png";
                if (icon.Equals("03n", StringComparison.InvariantCultureIgnoreCase)) //scattered clouds
                    return "/Icons/weezle_moon_cloud_medium.png";
                if (icon.Equals("04n", StringComparison.InvariantCultureIgnoreCase)) //broken clouds
                    return "/Icons/weezle_max_cloud.png";
                if (icon.Equals("09n", StringComparison.InvariantCultureIgnoreCase)) //shower rain
                    return "/Icons/weezle_medium_rain.png";
                if (icon.Equals("10n", StringComparison.InvariantCultureIgnoreCase)) //Rain
                    return "/Icons/weezle_rain.png";
                if (icon.Equals("11n", StringComparison.InvariantCultureIgnoreCase)) //Thunderstorm
                    return "/Icons/weezle_cloud_thunder_rain.png";
                if (icon.Equals("13n", StringComparison.InvariantCultureIgnoreCase)) //snow
                    return "/Icons/weezle_night_and_snow.png";
                if (icon.Equals("50n", StringComparison.InvariantCultureIgnoreCase)) //mist 
                    return "/Icons/weezle_night_fog.png";
            }
            return "/Icons/weezle_cloud_sun.png";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }

        #endregion
    }
}