using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

using Ninject;

using Domain.Data.Abstraction;
using Domain.Data.Concretic.EF;
using Services.Abstraction;
using Services.Concretic;

namespace Web.Util
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        public NinjectDependencyResolver(IKernel kernel)
        {
            _kernel = kernel;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return _kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            _kernel.Bind<IWeatherService>().To<OpenWeatherService>();
            _kernel.Bind<ICitiesService>().To<OpenWeatherCitiesService>();
            _kernel.Bind<IHistoryService>().To<HistoryService>();
        }

        private IKernel _kernel;
    }
}