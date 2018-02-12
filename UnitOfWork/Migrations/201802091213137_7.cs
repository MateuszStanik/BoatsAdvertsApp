namespace UnitOfWork.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _7 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DicCatogories", "Nam2e", c => c.String(unicode: false));
            
        }
        
        public override void Down()
        {

        }
    }
}
