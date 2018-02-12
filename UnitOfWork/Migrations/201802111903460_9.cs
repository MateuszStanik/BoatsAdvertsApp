namespace UnitOfWork.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _9 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Adverts", "Name", c => c.String(unicode: false));
            AddColumn("dbo.Adverts", "SureName", c => c.String(unicode: false));
            AddColumn("dbo.Adverts", "Email", c => c.String(unicode: false));
            AddColumn("dbo.Adverts", "City", c => c.String(unicode: false));
            AddColumn("dbo.Adverts", "AdditionalInformation", c => c.String(unicode: false));
            DropColumn("dbo.Adverts", "Mail");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Adverts", "Mail", c => c.String(unicode: false));
            DropColumn("dbo.Adverts", "AdditionalInformation");
            DropColumn("dbo.Adverts", "City");
            DropColumn("dbo.Adverts", "Email");
            DropColumn("dbo.Adverts", "SureName");
            DropColumn("dbo.Adverts", "Name");
        }
    }
}
