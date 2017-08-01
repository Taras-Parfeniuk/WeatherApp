using System.Collections.ObjectModel;
using System.Windows.Input;

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Views;

using Uwp.Models.DTO;
using Uwp.Models;
using Uwp.ViewModels;

namespace Uwp.ViewModels
{
    public class DefaultCitiesViewModel : BaseViewModel
    {
        public ObservableCollection<City> Cities { get; private set; }

        public City SelectedCity
        {
            get { return _selectedCity; }
            set
            {
                _selectedCity = value;
                if (_selectedCity != null)
                {
                    MessengerInstance.Send(_selectedCity);
                    _selectedCity = null;
                    _navigationService.NavigateTo(nameof(CurrentWeatherViewModel));
                }

                RaisePropertyChanged(() => SelectedCity);
            }
        }

        public DefaultCitiesViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Home";
            Cities = new ObservableCollection<City>();
            _defaultCities.LoadCities();
            _defaultCities.DefaultCitiesLoaded += UpdateCities;
        }

        private void UpdateCities(object sender, DefaultCitiesLoadedEventArgs e)
        {
            foreach (var city in _defaultCities.Cities)
            {
               Cities.Add(city);
            }
        }

        private City _selectedCity;
    }
}
