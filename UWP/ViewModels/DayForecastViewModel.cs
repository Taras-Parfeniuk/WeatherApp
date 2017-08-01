using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Uwp.Models.DTO;

namespace Uwp.ViewModels
{
    public class DayForecastViewModel : BaseViewModel
    {
        public ObservableCollection<SingleForecast> Forecasts { get; private set; }

        public ICommand GoBackCommand { get; set; }

        public DayForecastViewModel(INavigationService navigationService) : base(navigationService)
        {
            Forecasts = new ObservableCollection<SingleForecast>();
            GoBackCommand = new RelayCommand(GoBack);

            MessengerInstance.Register<Tuple<DateTime, List<SingleForecast>>>(this, day =>
            {
                Title = $"Forecast for {day.Item1.DayOfWeek.ToString()}";
                foreach(var forecast in day.Item2)
                {
                    Forecasts.Add(forecast);
                }
            });
        }

        private void GoBack()
        {
            _navigationService.GoBack();
        }
    }
}
