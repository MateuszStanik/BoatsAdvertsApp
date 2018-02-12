namespace UnitOfWork.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _11 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Boats", "ProducentName", c => c.String(unicode: false));
            AddColumn("dbo.Boats", "BoatModel", c => c.String(unicode: false));
            AddColumn("dbo.Boats", "Length", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Boats", "Beam", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Boats", "Weight", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.SailBoat", "YachtType", c => c.String(unicode: false));
            AddColumn("dbo.SailBoat", "RudderType", c => c.String(unicode: false));
            DropColumn("dbo.Boats", "BrandName");
            DropColumn("dbo.Boats", "Lenght");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Boats", "Lenght", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Boats", "BrandName", c => c.String(unicode: false));
            DropColumn("dbo.SailBoat", "RudderType");
            DropColumn("dbo.SailBoat", "YachtType");
            DropColumn("dbo.Boats", "Weight");
            DropColumn("dbo.Boats", "Beam");
            DropColumn("dbo.Boats", "Length");
            DropColumn("dbo.Boats", "BoatModel");
            DropColumn("dbo.Boats", "ProducentName");
        }
    }
}
