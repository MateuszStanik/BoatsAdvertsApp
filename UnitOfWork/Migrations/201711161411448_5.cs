namespace UnitOfWork.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _5 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MotorBoat",
                c => new
                    {
                        SubjectId = c.Long(nullable: false),
                        EnginePower = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MotorboatType = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.SubjectId)
                .ForeignKey("dbo.Boats", t => t.SubjectId)
                .Index(t => t.SubjectId);
            
            CreateTable(
                "dbo.SailBoat",
                c => new
                    {
                        SubjectId = c.Long(nullable: false),
                        SailsArea = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsEngine = c.Boolean(nullable: false),
                        EnginePower = c.Decimal(nullable: false, precision: 18, scale: 2),
                        EngineType = c.Byte(nullable: false),
                        HullType = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.SubjectId)
                .ForeignKey("dbo.Boats", t => t.SubjectId)
                .Index(t => t.SubjectId);
            
            CreateTable(
                "dbo.Boats",
                c => new
                    {
                        SubjectId = c.Long(nullable: false),
                        BrandName = c.String(unicode: false),
                        Lenght = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BuiltYear = c.DateTime(nullable: false),
                        Draft = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Displacement = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.SubjectId)
                .ForeignKey("dbo.Subjects", t => t.SubjectId)
                .Index(t => t.SubjectId);
            
            AddColumn("dbo.Engines", "BuiltYear", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Boats", "SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.SailBoat", "SubjectId", "dbo.Boats");
            DropForeignKey("dbo.MotorBoat", "SubjectId", "dbo.Boats");
            DropIndex("dbo.Boats", new[] { "SubjectId" });
            DropIndex("dbo.SailBoat", new[] { "SubjectId" });
            DropIndex("dbo.MotorBoat", new[] { "SubjectId" });
            DropColumn("dbo.Engines", "BuiltYear");
            DropTable("dbo.Boats");
            DropTable("dbo.SailBoat");
            DropTable("dbo.MotorBoat");
        }
    }
}
