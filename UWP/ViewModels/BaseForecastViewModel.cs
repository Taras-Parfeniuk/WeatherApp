using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Uwp.Models;
using Uwp.Models.DTO;

namespace Uwp.ViewModels
{
    public class BaseForecastViewModel : BaseViewModel
    {
        public BaseForecastViewModel(INavigationService navigationService) : base(navigationService)
        {
            _instanceId = Guid.NewGuid();

            _model = Forecasts.GetInstance();

            GoToCurrentCommand = new RelayCommand(GoToCurrent);
            GoToHourlyCommand = new RelayCommand(GoToHourly);
            GoToDailyCommand = new RelayCommand(GoToDaily);
        }

        public ICommand GoToCurrentCommand { get; set; }
        public ICommand GoToHourlyCommand { get; set; }
        public ICommand GoToDailyCommand { get; set; }

        protected void GoToCurrent()
        {
            MessengerInstance.Send<City>(_city);
            _navigationService.NavigateTo(nameof(CurrentWeatherViewModel));
        }

        protected void GoToHourly()
        {
            MessengerInstance.Send<City>(_city);
            _navigationService.NavigateTo(nameof(HourlyForecastViewModel));
        }

        protected void GoToDaily()
        {
            MessengerInstance.Send<City>(_city);
            _navigationService.NavigateTo(nameof(DailyForecastViewModel));
        }

        protected virtual void OnForecastLoad(object sender, ForecastLoadedEventArgs e) { }

        protected City _city;
        protected Forecasts _model;
        protected Guid _instanceId;
    }
}
