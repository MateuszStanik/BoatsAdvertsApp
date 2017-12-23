namespace UnitOfWork.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Adverts",
                c => new
                    {
                        AdvertId = c.Long(nullable: false, identity: true),
                        AdditionDate = c.DateTime(),
                        FinishDate = c.DateTime(),
                        UserId = c.Int(nullable: false),
                        Mail = c.String(unicode: false),
                        PhoneNumber = c.String(unicode: false),
                        SubjectId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.AdvertId)
                .ForeignKey("dbo.Subjects", t => t.SubjectId, cascadeDelete: true)
                .Index(t => t.SubjectId);
            
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        SubjectId = c.Long(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.SubjectId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Adverts", "SubjectId", "dbo.Subjects");
            DropIndex("dbo.Adverts", new[] { "SubjectId" });
            DropTable("dbo.Subjects");
            DropTable("dbo.Adverts");
        }
    }
}
