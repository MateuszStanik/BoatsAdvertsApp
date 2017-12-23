namespace UnitOfWork.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _4 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Engines",
                c => new
                    {
                        SubjectId = c.Long(nullable: false),
                        Brand = c.String(unicode: false),
                        Power = c.Double(nullable: false),
                        Type = c.String(unicode: false),
                        FuelType = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.SubjectId)
                .ForeignKey("dbo.Subjects", t => t.SubjectId)
                .Index(t => t.SubjectId);
            
            CreateTable(
                "dbo.Sails",
                c => new
                    {
                        SubjectId = c.Long(nullable: false),
                        LeechLenght = c.Double(nullable: false),
                        FootLenght = c.Double(nullable: false),
                        LuffLenght = c.Double(nullable: false),
                        Brand = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.SubjectId)
                .ForeignKey("dbo.Subjects", t => t.SubjectId)
                .Index(t => t.SubjectId);
            
            AddColumn("dbo.Subjects", "Name", c => c.String(unicode: false));
            AddColumn("dbo.Subjects", "Description", c => c.String(unicode: false));
            AddColumn("dbo.Subjects", "Price", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sails", "SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.Engines", "SubjectId", "dbo.Subjects");
            DropIndex("dbo.Sails", new[] { "SubjectId" });
            DropIndex("dbo.Engines", new[] { "SubjectId" });
            DropColumn("dbo.Subjects", "Price");
            DropColumn("dbo.Subjects", "Description");
            DropColumn("dbo.Subjects", "Name");
            DropTable("dbo.Sails");
            DropTable("dbo.Engines");
        }
    }
}
