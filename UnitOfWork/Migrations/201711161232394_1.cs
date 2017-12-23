namespace UnitOfWork.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Adverts", "SubjectId", "dbo.Subjects");
            DropIndex("dbo.Adverts", new[] { "SubjectId" });
            AddColumn("dbo.Subjects", "AdvertId", c => c.Long(nullable: false));
            CreateIndex("dbo.Subjects", "AdvertId");
            AddForeignKey("dbo.Subjects", "AdvertId", "dbo.Adverts", "AdvertId", cascadeDelete: true);
            DropColumn("dbo.Adverts", "SubjectId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Adverts", "SubjectId", c => c.Long(nullable: false));
            DropForeignKey("dbo.Subjects", "AdvertId", "dbo.Adverts");
            DropIndex("dbo.Subjects", new[] { "AdvertId" });
            DropColumn("dbo.Subjects", "AdvertId");
            CreateIndex("dbo.Adverts", "SubjectId");
            AddForeignKey("dbo.Adverts", "SubjectId", "dbo.Subjects", "SubjectId", cascadeDelete: true);
        }
    }
}
