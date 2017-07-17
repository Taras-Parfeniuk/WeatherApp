using System;
using Ninject.Modules;

using Domain.Data.Abstraction;
using Domain.Data.Concretic.EF;
using Services.Abstraction;
using Services.Concretic;

namespace Services.Util
{
    public class ServicesNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IForecastConverter>().To<OpenWeatherForecastConverter>();
            Bind<IHistoryService>().To<HistoryService>();
            Bind<ICitiesService>().To<OpenWeatherCitiesService>();
            Bind<IWeatherService>().To<OpenWeatherService>();
            Bind<ISelectedCitiesRepository>().To<SelectedCitiesRepository>();
            Bind<IHistoryRepository>().To<HistoryRepository>();

            Bind<OpenWeatherCitiesService>().ToConstructor(arg => new OpenWeatherCitiesService(arg.Inject<ISelectedCitiesRepository>()));
            Bind<HistoryService>().ToConstructor(arg => new HistoryService(arg.Inject<ICitiesService>(), arg.Inject<IHistoryRepository>()));
        }
    }
}
