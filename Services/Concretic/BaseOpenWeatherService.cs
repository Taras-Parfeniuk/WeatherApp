using Ninject;

using Services.Abstraction;
using Services.Util;

namespace Services.Concretic
{
    public class BaseOpenWeatherService
    {
        public BaseOpenWeatherService()
        {
            _kernel = new StandardKernel(new ServicesNinjectModule());
            _responseConverter = _kernel.Get<IForecastConverter>();
        }

        protected IKernel _kernel;
        protected const string _APIKEY = "9e37cc806b43d7a7425387e673677959";
        protected IForecastConverter _responseConverter;
    }
}
