using System.Linq;

using NUnit.Framework;
using Ninject;

using Domain.Entities.Concretic;
using Services.Abstraction;
using Services.Concretic;

using Services.Util;

namespace WeatherApp.Test.Services
{
    [TestFixture]
    public class OpenWeatherCitiesServiceTests
    {
        [Test]
        public void GetCityByName_When_given_string_name_of_city_Then_return_correct_city_object()
        {
            // Arrange
            IKernel kernel = new StandardKernel(new ServicesNinjectModule());
            ICitiesService citiesService = kernel.Get<ICitiesService>();
            string cityName = "lviv";
            City expected = new City()
            {
                Id = 702550,
                Name = "Lviv",
                Country = "UA"
            };

            // Act
            City obj = citiesService.GetCityByName(cityName);

            //Assert
            Assert.AreEqual(expected.Country, obj.Country);
            Assert.AreEqual(expected.Id, obj.Id);
            Assert.AreEqual(expected.Name, obj.Name);
        }

        [Test]
        public void GetCityById_When_given_int_id_of_city_Then_return_correct_city_object()
        {
            // Arrange
            IKernel kernel = new StandardKernel(new ServicesNinjectModule());
            ICitiesService citiesService = kernel.Get<ICitiesService>();
            int cityId = 702550;
            City expected = new City()
            {
                Id = 702550,
                Name = "Lviv",
                Country = "UA"
            };

            // Act
            City obj = citiesService.GetCityById(cityId);

            //Assert
            Assert.AreEqual(expected.Country, obj.Country);
            Assert.AreEqual(expected.Id, obj.Id);
            Assert.AreEqual(expected.Name, obj.Name);
        }

        [Test]
        public void AddToSelected_When_given_city_Then_Add_it_to_selected_cities_and_return_it()
        {
            IKernel kernel = new StandardKernel(new ServicesNinjectModule());
            ICitiesService citiesService = kernel.Get<ICitiesService>();
            City expected = new City()
            {
                Id = 702550,
                Name = "Lviv",
                Country = "UA"
            };

            // Act
            citiesService.AddToSelected(expected);
            City actual = citiesService.GetSelected().FirstOrDefault(c => c.Id == expected.Id);

            //Assert
            Assert.IsNotNull(actual);
            Assert.Multiple(() =>
            {
                Assert.AreEqual(expected.Name, actual.Name);
                Assert.AreEqual(expected.Country, actual.Country);
            });
        }

        [Test]
        public void RemoveFromSelected_When_given_city_add_it_to_selected_Then_remove_it()
        {
            IKernel kernel = new StandardKernel(new ServicesNinjectModule());
            ICitiesService citiesService = kernel.Get<ICitiesService>();
            City expected = new City()
            {
                Id = 702550,
                Name = "Lviv",
                Country = "UA"
            };

            // Act
            citiesService.AddToSelected(expected);
            
            citiesService.RemoveFromSelected(expected);
            City actual = citiesService.GetSelected().FirstOrDefault(c => c.Id == expected.Id);

            //Assert
            Assert.IsNull(actual);
        }
    }
}
