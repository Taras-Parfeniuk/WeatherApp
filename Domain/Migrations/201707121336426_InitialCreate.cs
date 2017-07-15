namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ForecastQueryInfoes", t => t.ForecastQueryInfo_Id)
                .Index(t => t.ForecastQueryInfo_Id);
            
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
                "dbo.SelectedCities",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(),
                        Country = c.String(),
                        Coordinates_Longitude = c.Double(),
                        Coordinates_Latitude = c.Double(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StoredForecasts", "ForecastQueryInfo_Id", "dbo.ForecastQueryInfoes");
            DropIndex("dbo.StoredForecasts", new[] { "ForecastQueryInfo_Id" });
            DropTable("dbo.SelectedCities");
            DropTable("dbo.ForecastQueryInfoes");
            DropTable("dbo.StoredForecasts");
        }
    }
}
