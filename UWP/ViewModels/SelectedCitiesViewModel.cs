﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;

using Uwp.Models.DTO;
using Uwp.Models;
using System.Windows.Input;
using System.Collections.ObjectModel;

namespace Uwp.ViewModels
{
    public class SelectedCitiesViewModel : BaseViewModel
    {
        public ObservableCollection<City> Cities { get; private set; }

        public string NewCityName
        {
            get
            {
                return _newCityName;
            }
            set
            {
                _newCityName = value;
                RaisePropertyChanged(() => NewCityName);
            }
        }

        public City SelectedCity
        {
            get
            {
                return _selectedCity;
            }
            set
            {
                _selectedCity = value;
                RaisePropertyChanged(() => SelectedCity);
            }
        }

        public ICommand RemoveCommand { get; set; }
        public ICommand ForecastForSelectedCommand { get; set; }
        public ICommand AddToSelectedCommand { get; set; }

        public SelectedCitiesViewModel(INavigationService navigationService) : base(navigationService)
        {
            _selectedCities = new SelectedCities();
            Title = "Selected cities";
            Cities = new ObservableCollection<City>();

            RemoveCommand = new RelayCommand(RemoveSelected);
            ForecastForSelectedCommand = new RelayCommand(ForecastForSelected);
            AddToSelectedCommand = new RelayCommand(AddToSelected);

            LoadCities();
        }

        private async void AddToSelected()
        {
            await _selectedCities.Add(_newCityName);
            LoadCities();
        }

        private void ForecastForSelected()
        {
            if (_selectedCity != null)
            {
                MessengerInstance.Send(_selectedCity);
                _selectedCity = null;
                _navigationService.NavigateTo(nameof(CurrentWeatherViewModel));
            }
        }

        private async void RemoveSelected()
        {
            if (_selectedCity != null)
            {
                await _selectedCities.Remove(_selectedCity);
                _selectedCity = null;
                LoadCities();
            }
        }

        private async void LoadCities()
        {
            await _selectedCities.LoadCities();
            Cities.Clear();

            foreach (var city in _selectedCities.Cities)
            {
                Cities.Add(city);
            }
        }

        private string _newCityName;
        private City _selectedCity;
        private SelectedCities _selectedCities;
    }
}
