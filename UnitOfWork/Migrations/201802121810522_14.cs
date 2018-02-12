namespace UnitOfWork.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _14 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DicYearbooks", "CategoryId", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DicYearbooks", "CategoryId");
        }
    }
}
