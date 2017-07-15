namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class refactorMigration : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.SelectedCities", newName: "Cities");
            DropForeignKey("dbo.StoredForecasts", "ForecastQueryInfo_Id", "dbo.ForecastQueryInfoes");
            DropIndex("dbo.StoredForecasts", new[] { "ForecastQueryInfo_Id" });
            DropPrimaryKey("dbo.Cities");
            CreateTable(
                "dbo.Forecasts",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        MorningTemperature = c.Double(),
                        DayTemperature = c.Double(),
                        EveningTemperature = c.Double(),
                        CurrentTemperature = c.Double(),
                        Sunrise = c.DateTime(nullable: false),
                        Sunset = c.DateTime(nullable: false),
                        WeatherIcon = c.String(),
                        WeatherState = c.String(),
                        WeatherDescription = c.String(),
                        MinTemperature = c.Double(),
                        MaxTemperature = c.Double(),
                        DefaultPressure = c.Int(),
                        Humidity = c.Int(),
                        WindSpeed = c.Double(),
                        Cloudiness = c.Double(),
                        ForecastTime = c.DateTime(nullable: false),
                        HistoryEntry_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.HistoryEntries", t => t.HistoryEntry_Id)
                .Index(t => t.HistoryEntry_Id);
            
            CreateTable(
                "dbo.HistoryEntries",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CityId = c.Int(nullable: false),
                        Time = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AlterColumn("dbo.Cities", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Cities", "Id");
            DropColumn("dbo.Cities", "Coordinates_Longitude");
            DropColumn("dbo.Cities", "Coordinates_Latitude");
            DropTable("dbo.StoredForecasts");
            DropTable("dbo.ForecastQueryInfoes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ForecastQueryInfoes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        QueryTime = c.DateTime(nullable: false),
                        CityId = c.Int(nullable: false),
                        CityName = c.String(),
                        CityCountry = c.String(),
                        CityLongitude = c.Double(),
                        CityLatitude = c.Double(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StoredForecasts",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Weather = c.String(),
                        MinTemperature = c.Double(),
                        MaxTemperature = c.Double(),
                        ForecastTime = c.DateTime(nullable: false),
                        QueryId = c.Guid(nullable: false),
                        ForecastQueryInfo_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Cities", "Coordinates_Latitude", c => c.Double());
            AddColumn("dbo.Cities", "Coordinates_Longitude", c => c.Double());
            DropForeignKey("dbo.Forecasts", "HistoryEntry_Id", "dbo.HistoryEntries");
            DropIndex("dbo.Forecasts", new[] { "HistoryEntry_Id" });
            DropPrimaryKey("dbo.Cities");
            AlterColumn("dbo.Cities", "Id", c => c.Int(nullable: false));
            DropTable("dbo.HistoryEntries");
            DropTable("dbo.Forecasts");
            AddPrimaryKey("dbo.Cities", "Id");
            CreateIndex("dbo.StoredForecasts", "ForecastQueryInfo_Id");
            AddForeignKey("dbo.StoredForecasts", "ForecastQueryInfo_Id", "dbo.ForecastQueryInfoes", "Id");
            RenameTable(name: "dbo.Cities", newName: "SelectedCities");
        }
    }
}
