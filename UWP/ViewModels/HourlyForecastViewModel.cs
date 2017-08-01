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
    public class HourlyForecastViewModel : BaseForecastViewModel
    {
        public string CityName { get; private set; }

        public Tuple<DateTime, List<SingleForecast>> SelectedDay
        {
            get { return _selectedDay; }
            set
            {
                _selectedDay = value;
                if (_selectedDay != null)
                {
                    MessengerInstance.Send(_selectedDay);
                    _navigationService.NavigateTo(nameof(DayForecastViewModel));
                }

                RaisePropertyChanged(() => SelectedDay);
            }
        }

        public ObservableCollection<Tuple<DateTime, List<SingleForecast>>> Days { get; private set; }

        public HourlyForecastViewModel(INavigationService navigationService) : base(navigationService)
        {
            Days = new ObservableCollection<Tuple<DateTime, List<SingleForecast>>>();

            MessengerInstance.Register<City>(this, city =>
            {
                _model.SetCity(city);
                _city = city;
                CityName = $"{city.Name}, {city.Country}";
                RaisePropertyChanged(() => CityName);
                _model.LoadHourlyForecastAsync(_instanceId);
                _model.ForecastLoaded += OnForecastLoad;
            });
        }

        override protected void OnForecastLoad(object sender, ForecastLoadedEventArgs e)
        {
            if (e.RecipientId == _instanceId)
            {
                _forecast = _model.HourlyForecast;

                Days.Clear();

                var days = _forecast.SingleForecasts.GroupBy(f => f.ForecastTime.Date);
                var sortedDays = new ObservableCollection<Tuple<DateTime, SingleForecast>>();

                foreach (IGrouping<DateTime, SingleForecast> d in days)
                {
                    var day = new Tuple<DateTime, List<SingleForecast>>(d.Key, d.ToList());
                    Days.Add(day);
                }
            }
        }

        private Tuple<DateTime, List<SingleForecast>> _selectedDay;
        private MultipleForecast _forecast;
    }
}
