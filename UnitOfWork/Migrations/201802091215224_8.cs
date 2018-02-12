namespace UnitOfWork.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _8 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DicCatogories", "Name", c => c.String(unicode: false));
            DropColumn("dbo.DicCatogories", "Nam2e");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DicCatogories", "Nam2e", c => c.String(unicode: false));
            DropColumn("dbo.DicCatogories", "Name");
        }
    }
}
