namespace UnitOfWork.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sails", "SailArea", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Sails", "SailArea");
        }
    }
}
