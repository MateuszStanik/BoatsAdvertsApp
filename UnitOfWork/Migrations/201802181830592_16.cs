namespace UnitOfWork.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _16 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SubjectImages",
                c => new
                    {
                        ImageID = c.Int(nullable: false, identity: true),
                        SubjectId = c.Long(nullable: false),
                        Name = c.String(unicode: false),
                        ImageData = c.Binary(),
                    })
                .PrimaryKey(t => t.ImageID);
            
            AddColumn("dbo.Subjects", "Images_ImageID", c => c.Int());
            CreateIndex("dbo.Subjects", "Images_ImageID");
            AddForeignKey("dbo.Subjects", "Images_ImageID", "dbo.SubjectImages", "ImageID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Subjects", "Images_ImageID", "dbo.SubjectImages");
            DropIndex("dbo.Subjects", new[] { "Images_ImageID" });
            DropColumn("dbo.Subjects", "Images_ImageID");
            DropTable("dbo.SubjectImages");
        }
    }
}
