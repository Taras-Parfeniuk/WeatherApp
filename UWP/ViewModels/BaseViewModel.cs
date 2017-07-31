using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System.Windows.Input;
using Uwp.Models;
using Uwp.Models.DTO;

namespace Uwp.ViewModels
{
    public class BaseViewModel : ViewModelBase
    {
        public ICommand CitySearchCommand { get; set; }

        public ICommand GoToHomeCommand { get; set; }
        public ICommand GoToSelectedCitiesCommand { get; set; }
        public ICommand GoToHistoryCommand { get; set; }

        public string CitySearchFilter
        {
            get { return _citySearchFilter; }
            set
            {
                _citySearchFilter = value;
                RaisePropertyChanged(() => CitySearchFilter);
            }
        }

        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                RaisePropertyChanged(() => Title);
            }
        }

        protected void GoToHome()
        {
            _navigationService.NavigateTo(nameof(DefaultCitiesViewModel));
        }

        protected void GoToSelectedCities()
        {
            _navigationService.NavigateTo(nameof(SelectedCitiesViewModel));
        }

        protected void GoToHistory()
        {
            _navigationService.NavigateTo(nameof(HistoryViewModel));
        }

        public BaseViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            _defaultCities = DefaultCities.GetInstance();

            CitySearchCommand = new RelayCommand(Search);
            GoToHomeCommand = new RelayCommand(GoToHome);
            GoToSelectedCitiesCommand = new RelayCommand(GoToSelectedCities);
            GoToHistoryCommand = new RelayCommand(GoToHistory);
            CitySearchFilter = "";
        }

        protected async void Search()
        {
            if (!string.IsNullOrWhiteSpace(CitySearchFilter))
            {
                var city = await _defaultCities.GetByNameAsync(CitySearchFilter);
                MessengerInstance.Send(city);
                _navigationService.NavigateTo(nameof(CurrentWeatherViewModel));
            }
        }

        protected string _title;
        protected string _citySearchFilter;
        protected DefaultCities _defaultCities;
        protected INavigationService _navigationService;
    }
}
