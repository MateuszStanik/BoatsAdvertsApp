namespace UnitOfWork.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _10 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Subjects", "AdvertName", c => c.String(unicode: false));
            AddColumn("dbo.Subjects", "AdvertDescription", c => c.String(unicode: false));
            DropColumn("dbo.Subjects", "Name");
            DropColumn("dbo.Subjects", "Description");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Subjects", "Description", c => c.String(unicode: false));
            AddColumn("dbo.Subjects", "Name", c => c.String(unicode: false));
            DropColumn("dbo.Subjects", "AdvertDescription");
            DropColumn("dbo.Subjects", "AdvertName");
        }
    }
}
