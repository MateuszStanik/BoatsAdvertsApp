namespace UnitOfWork.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _8 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Engines", "BuiltYear", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Engines", "BuiltYear", c => c.DateTime(nullable: false));
        }
    }
}
