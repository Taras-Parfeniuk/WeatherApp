using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;

using Uwp.Models.DTO;
using Uwp.Models;

namespace Uwp.ViewModels
{
    public class DailyForecastViewModel : BaseForecastViewModel
    {
        public string CityName { get; private set; }

        public ObservableCollection<SingleForecast> Days { get; private set; }

        public DailyForecastViewModel(INavigationService navigationService) : base(navigationService)
        {
            Days = new ObservableCollection<SingleForecast>();

            MessengerInstance.Register<City>(this, city =>
            {
                _model.SetCity(city);
                _city = city;
                CityName = $"{_city.Name}, {_city.Country}";
                RaisePropertyChanged(() => CityName);
                _model.LoadDailyForecastAsync(_instanceId);
                _model.ForecastLoaded += OnForecastLoad;
            });
        }

        override protected void OnForecastLoad(object sender, ForecastLoadedEventArgs e)
        {
            if (e.RecipientId == _instanceId)
            {
                _forecast = _model.DailyForecast;

                foreach (var day in _forecast.SingleForecasts)
                {
                    Days.Add(day);
                }
                Title = $"{_forecast.City.Name}, {_forecast.City.Country}";

            }
        }

        private MultipleForecast _forecast;
    }
}
