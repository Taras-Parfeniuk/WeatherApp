namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editCitiesTable : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.SelectedCities");
            AlterColumn("dbo.SelectedCities", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.SelectedCities", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.SelectedCities");
            AlterColumn("dbo.SelectedCities", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.SelectedCities", "Id");
        }
    }
}
