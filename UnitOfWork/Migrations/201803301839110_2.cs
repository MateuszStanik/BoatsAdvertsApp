namespace UnitOfWork.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accessories",
                c => new
                    {
                        SubjectId = c.Long(nullable: false),
                        Brand = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.SubjectId)
                .ForeignKey("dbo.Subjects", t => t.SubjectId)
                .Index(t => t.SubjectId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Accessories", "SubjectId", "dbo.Subjects");
            DropIndex("dbo.Accessories", new[] { "SubjectId" });
            DropTable("dbo.Accessories");
        }
    }
}
