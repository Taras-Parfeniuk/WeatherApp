namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenamedForecaststable : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Forecasts", newName: "StoredForecasts");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.StoredForecasts", newName: "Forecasts");
        }
    }
}
