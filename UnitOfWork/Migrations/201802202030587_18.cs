namespace UnitOfWork.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _18 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Subjects", "Images_ImageID", "dbo.SubjectImages");
            DropIndex("dbo.Subjects", new[] { "Images_ImageID" });
            AddColumn("dbo.SubjectImages", "Subject_SubjectId", c => c.Long());
            CreateIndex("dbo.SubjectImages", "Subject_SubjectId");
            AddForeignKey("dbo.SubjectImages", "Subject_SubjectId", "dbo.Subjects", "SubjectId");
            DropColumn("dbo.Subjects", "Images_ImageID");
            DropColumn("dbo.SubjectImages", "SubjectId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SubjectImages", "SubjectId", c => c.Long(nullable: false));
            AddColumn("dbo.Subjects", "Images_ImageID", c => c.Int());
            DropForeignKey("dbo.SubjectImages", "Subject_SubjectId", "dbo.Subjects");
            DropIndex("dbo.SubjectImages", new[] { "Subject_SubjectId" });
            DropColumn("dbo.SubjectImages", "Subject_SubjectId");
            CreateIndex("dbo.Subjects", "Images_ImageID");
            AddForeignKey("dbo.Subjects", "Images_ImageID", "dbo.SubjectImages", "ImageID");
        }
    }
}
