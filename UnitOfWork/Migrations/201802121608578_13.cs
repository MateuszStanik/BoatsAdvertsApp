namespace UnitOfWork.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _13 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Boats", "BuiltYear", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Boats", "BuiltYear", c => c.DateTime(nullable: false));
        }
    }
}
