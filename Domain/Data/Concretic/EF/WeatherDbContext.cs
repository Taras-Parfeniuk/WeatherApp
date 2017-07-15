using System.Data.Entity;

using Domain.Entities.Concretic;

namespace Domain.Data.Concretic.EF
{
    public class WeatherDbContext : DbContext
    {
        public DbSet<City> SelectedCities { get; set; }
        public DbSet<Forecast> Forecasts { get; set; }
        public DbSet<HistoryEntry> History { get; set; }

        public WeatherDbContext() : base("WeatherDbContext") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HistoryEntry>().
                Property(e => e.Time)
                .HasColumnType("datetime2");

            modelBuilder.Entity<Forecast>()
                .Property(f => f.ForecastTime)
                .HasColumnType("datetime2");

            modelBuilder.Entity<Forecast>()
                .Property(f => f.Sunrise)
                .HasColumnType("datetime2");

            modelBuilder.Entity<Forecast>()
                .Property(f => f.Sunset)
                .HasColumnType("datetime2");

            modelBuilder.Entity<City>().ToTable("SelectedCities");
        }
    }
}
