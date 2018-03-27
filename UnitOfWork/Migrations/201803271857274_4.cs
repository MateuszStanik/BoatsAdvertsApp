namespace UnitOfWork.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SubjectImages", "Subject_SubjectId", "dbo.Subjects");
            DropIndex("dbo.SubjectImages", new[] { "Subject_SubjectId" });
            RenameColumn(table: "dbo.SubjectImages", name: "Subject_SubjectId", newName: "SubjectId");
            CreateTable(
                "dbo.Trailors",
                c => new
                    {
                        SubjectId = c.Long(nullable: false),
                        Weight = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Length = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Width = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Capcity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Brand = c.String(unicode: false),
                        BuiltYear = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.SubjectId)
                .ForeignKey("dbo.Subjects", t => t.SubjectId)
                .Index(t => t.SubjectId);
            
            AlterColumn("dbo.Engines", "BuiltYear", c => c.String(unicode: false));
            AlterColumn("dbo.SubjectImages", "SubjectId", c => c.Long(nullable: false));
            CreateIndex("dbo.SubjectImages", "SubjectId");
            AddForeignKey("dbo.SubjectImages", "SubjectId", "dbo.Subjects", "SubjectId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SubjectImages", "SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.Trailors", "SubjectId", "dbo.Subjects");
            DropIndex("dbo.Trailors", new[] { "SubjectId" });
            DropIndex("dbo.SubjectImages", new[] { "SubjectId" });
            AlterColumn("dbo.SubjectImages", "SubjectId", c => c.Long());
            AlterColumn("dbo.Engines", "BuiltYear", c => c.DateTime(nullable: false));
            DropTable("dbo.Trailors");
            RenameColumn(table: "dbo.SubjectImages", name: "SubjectId", newName: "Subject_SubjectId");
            CreateIndex("dbo.SubjectImages", "Subject_SubjectId");
            AddForeignKey("dbo.SubjectImages", "Subject_SubjectId", "dbo.Subjects", "SubjectId");
        }
    }
}
