namespace UnitOfWork.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _3 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Adverts", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Adverts", "UserId", c => c.Int(nullable: false));
        }
    }
}
