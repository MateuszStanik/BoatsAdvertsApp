namespace UnitOfWork.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _17 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SubjectImages", "Identifier", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SubjectImages", "Identifier");
        }
    }
}
