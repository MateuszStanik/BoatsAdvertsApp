namespace UnitOfWork.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _15 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.DicYearbooks", "CategoryId", c => c.Int(nullable: false));
            AlterColumn("dbo.DicYearbooks", "Year", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.DicYearbooks", "Year", c => c.String(unicode: false));
            AlterColumn("dbo.DicYearbooks", "CategoryId", c => c.String(unicode: false));
        }
    }
}
