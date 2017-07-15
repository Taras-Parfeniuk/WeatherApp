namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class renameCitiesTable : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Cities", newName: "SelectedCities");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.SelectedCities", newName: "Cities");
        }
    }
}
