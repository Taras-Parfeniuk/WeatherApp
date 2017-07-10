using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.Entity;

using Domain.Entities.Location;
using Domain.Entities.Forecast;
using Domain.Entities;

namespace Domain.Data.Concretic.EF
{
    public class WeatherDbContext : DbContext
    {
        public DbSet<City> Cities { get; set; }
        public DbSet<City> ElectedCities { get; set; }
        public DbSet<DayForecast> Forecasts { get; set; }
        public DbSet<ForecastQueryInfo> Queries { get; set; }

        public WeatherDbContext() : base(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString) { }
    }
}
