namespace UnitOfWork.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _12 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DicYearbooks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Year = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.DicYearbooks");
        }
    }
}
