/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:MeteoWP"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using GalaSoft.MvvmLight.Ioc;
using MeteoWP.Service.SettingsService;
using MeteoWP.Service.WeatherApiService;
using MeteoWP.ViewModel.Forecast;
using MeteoWP.ViewModel.Settings;
using Microsoft.Practices.ServiceLocation;

namespace MeteoWP.ViewModel
{
    /// <summary>
    ///     This class contains static references to all the view models in the
    ///     application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        ///     Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<ISettingsService, SettingsService>();
            SimpleIoc.Default.Register<IWeatherApiService, WeatherApiService>();
            SimpleIoc.Default.Register<ISettingsViewModel, SettingsViewModel>();
            SimpleIoc.Default.Register<IForecastViewModel, ForecastViewModel>();
            SimpleIoc.Default.Register<MainViewModel>();
        }

        public MainViewModel MainPage
        {
            get { return ServiceLocator.Current.GetInstance<MainViewModel>(); }
        }

        public ISettingsViewModel Settings
        {
            get { return ServiceLocator.Current.GetInstance<ISettingsViewModel>(); }
        }

        public IForecastViewModel Forecast
        {
            get { return ServiceLocator.Current.GetInstance<IForecastViewModel>(); }
        }

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}