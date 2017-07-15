namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editDateTimeTypes : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Forecasts", "Sunrise", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Forecasts", "Sunset", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Forecasts", "ForecastTime", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.HistoryEntries", "Time", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.HistoryEntries", "Time", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Forecasts", "ForecastTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Forecasts", "Sunset", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Forecasts", "Sunrise", c => c.DateTime(nullable: false));
        }
    }
}
