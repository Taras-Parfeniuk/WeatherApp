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
        public DbSet<SelectedCity> SelectedCities { get; set; }
        public DbSet<StoredForecast> Forecasts { get; set; }
        public DbSet<ForecastQueryInfo> Queries { get; set; }

        public WeatherDbContext() : base("WeatherDbContext")
        {        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SelectedCity>()
                .Map(m =>
                {
                    m.MapInheritedProperties();
                    m.ToTable("SelectedCities");
                });

            modelBuilder.Entity<ForecastQueryInfo>()
                .Property(q => q.City.Id)
                .HasColumnName("CityId");

            modelBuilder.Entity<ForecastQueryInfo>()
                .Property(q => q.City.Name)
                .HasColumnName("CityName");

            modelBuilder.Entity<ForecastQueryInfo>()
                .Property(q => q.City.Country)
                .HasColumnName("CityCountry");

            modelBuilder.Entity<ForecastQueryInfo>()
                .Property(q => q.City.Coordinates.Latitude)
                .HasColumnName("CityLatitude");

            modelBuilder.Entity<ForecastQueryInfo>()
                .Property(q => q.City.Coordinates.Longitude)
                .HasColumnName("CityLongitude");

            modelBuilder.Entity<ForecastQueryInfo>()
                .HasMany(q => q.Forecasts);
        }
    }
}
