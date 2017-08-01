using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using Uwp.ViewModels;
using Uwp.Views;

namespace Uwp
{
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            var navigationService = new NavigationService();
            navigationService.Configure(nameof(DefaultCitiesViewModel), typeof(HomeView));
            navigationService.Configure(nameof(CurrentWeatherViewModel), typeof(CurrentWeatherView));
            navigationService.Configure(nameof(HourlyForecastViewModel), typeof(HourlyForecastView));
            navigationService.Configure(nameof(DailyForecastViewModel), typeof(DailyForecastView));
            navigationService.Configure(nameof(HistoryViewModel), typeof(HistoryView));
            navigationService.Configure(nameof(HistoryEntryViewModel), typeof(HistoryEntryView));
            navigationService.Configure(nameof(SelectedCitiesViewModel), typeof(SelectedCitiesView));
            navigationService.Configure(nameof(DayForecastViewModel), typeof(DayForecastView));

            if (ViewModelBase.IsInDesignModeStatic)
            {
                // Create design time view services and models
            }
            else
            {
                // Create run time view services and models
            }

            //Register your services used here
            //SimpleIoc.Default.Register<INavigationService, NavigationService>();
            SimpleIoc.Default.Register<INavigationService>(() => navigationService);
            SimpleIoc.Default.Register<DefaultCitiesViewModel>();
            SimpleIoc.Default.Register<CurrentWeatherViewModel>();
            SimpleIoc.Default.Register<HourlyForecastViewModel>();
            SimpleIoc.Default.Register<DailyForecastViewModel>();
            SimpleIoc.Default.Register<HistoryViewModel>();
            SimpleIoc.Default.Register<HistoryEntryViewModel>();
            SimpleIoc.Default.Register<SelectedCitiesViewModel>();
            SimpleIoc.Default.Register<DayForecastViewModel>();

            ServiceLocator.Current.GetInstance<CurrentWeatherViewModel>();
            ServiceLocator.Current.GetInstance<HourlyForecastViewModel>();
            ServiceLocator.Current.GetInstance<DailyForecastViewModel>();
            ServiceLocator.Current.GetInstance<HistoryEntryViewModel>();
            ServiceLocator.Current.GetInstance<SelectedCitiesViewModel>();
            ServiceLocator.Current.GetInstance<DayForecastViewModel>();
        }


        // <summary>
        // Gets the Academy view model.
        // </summary>
        // <value>
        // The Academy view model.
        // </value>
        public DefaultCitiesViewModel DefaultCitiesVMInstance
        {
            get
            {
                return ServiceLocator.Current.GetInstance<DefaultCitiesViewModel>();
            }
        }

        public CurrentWeatherViewModel CurrentWeatherVMInstance
        {
            get
            {
                return ServiceLocator.Current.GetInstance<CurrentWeatherViewModel>();
            }
        }

        public HourlyForecastViewModel HourlyForecastVMInstance
        {
            get
            {
                return ServiceLocator.Current.GetInstance<HourlyForecastViewModel>();
            }
        }

        public DailyForecastViewModel DailyForecastVMInstance
        {
            get
            {
                return ServiceLocator.Current.GetInstance<DailyForecastViewModel>();
            }
        }

        public SelectedCitiesViewModel SelectedCitiesVMInstance
        {
            get
            {
                return ServiceLocator.Current.GetInstance<SelectedCitiesViewModel>();
            }
        }

        public HistoryViewModel HistoryVMInstance
        {
            get
            {
                return ServiceLocator.Current.GetInstance<HistoryViewModel>();
            }
        }

        public HistoryEntryViewModel HistoryEntryVMInstance
        {
            get
            {
                return ServiceLocator.Current.GetInstance<HistoryEntryViewModel>();
            }
        }
        
        public DayForecastViewModel DayForecastVMInstance
        {
            get
            {
                return ServiceLocator.Current.GetInstance<DayForecastViewModel>();
            }
        }

        // <summary>
        // The cleanup.
        // </summary>
        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}
