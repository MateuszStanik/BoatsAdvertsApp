namespace UnitOfWork.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _6 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Engines", "TypeOfEngine", c => c.Int(nullable: false));
            AddColumn("dbo.Engines", "TypeOfFuel", c => c.Int(nullable: false));
            DropColumn("dbo.Engines", "Type");
            DropColumn("dbo.Engines", "FuelType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Engines", "FuelType", c => c.String(unicode: false));
            AddColumn("dbo.Engines", "Type", c => c.String(unicode: false));
            DropColumn("dbo.Engines", "TypeOfFuel");
            DropColumn("dbo.Engines", "TypeOfEngine");
        }
    }
}
