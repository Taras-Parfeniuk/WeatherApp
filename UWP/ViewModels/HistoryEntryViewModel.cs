using System;
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
    public class HistoryEntryViewModel : BaseViewModel
    {
        public ObservableCollection<SingleForecast> Forecasts { get; private set; }

        public ICommand GoBackCommand { get; set; }

        public HistoryEntryViewModel(INavigationService navigationService) : base(navigationService)
        {
            Forecasts = new ObservableCollection<SingleForecast>();

            MessengerInstance.Register<HistoryEntry>(this, entry => 
            {
                _entry = entry;
                _title = $"{_entry.City.Name}, {_entry.City.Country} ({_entry.QueryTime.ToString()})";
                RaisePropertyChanged(() => Title);

                LoadForecasts();
            });
        }

        private async void LoadForecasts()
        {
            await _entry.LoadForecasts();

            foreach (var f in _entry.Forecasts)
            {
                Forecasts.Add(f);
            }
        }

        private void GoBack()
        {
            _navigationService.GoBack();
        }

        private HistoryEntry _entry;
    }
}
