namespace UnitOfWork.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _6 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128, unicode: false),
                        Name = c.String(nullable: false, maxLength: 256, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128, unicode: false),
                        Email = c.String(maxLength: 256, unicode: false),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(unicode: false),
                        SecurityStamp = c.String(unicode: false),
                        PhoneNumber = c.String(unicode: false),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128, unicode: false),
                        ClaimType = c.String(unicode: false),
                        ClaimValue = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128, unicode: false),
                        ProviderKey = c.String(nullable: false, maxLength: 128, unicode: false),
                        UserId = c.String(nullable: false, maxLength: 128, unicode: false),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.DicCatogories",
                c => new
                    {
                        CategoryId = c.Long(nullable: false, identity: true),
                        Id = c.String(unicode: false),
                        Name = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.DicYearbooks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryId = c.Int(nullable: false),
                        Year = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SubjectImages",
                c => new
                    {
                        ImageID = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                        Identifier = c.Guid(nullable: false),
                        ImageData = c.Binary(),
                        Subject_SubjectId = c.Long(),
                    })
                .PrimaryKey(t => t.ImageID)
                .ForeignKey("dbo.Subjects", t => t.Subject_SubjectId)
                .Index(t => t.Subject_SubjectId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        RoleId = c.String(nullable: false, maxLength: 128, unicode: false),
                        UserId = c.String(nullable: false, maxLength: 128, unicode: false),
                    })
                .PrimaryKey(t => new { t.RoleId, t.UserId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.RoleId)
                .Index(t => t.UserId);
            
            AddColumn("dbo.Adverts", "Name", c => c.String(unicode: false));
            AddColumn("dbo.Adverts", "SureName", c => c.String(unicode: false));
            AddColumn("dbo.Adverts", "Email", c => c.String(unicode: false));
            AddColumn("dbo.Adverts", "City", c => c.String(unicode: false));
            AddColumn("dbo.Adverts", "AdditionalInformation", c => c.String(unicode: false));
            AddColumn("dbo.Boats", "ProducentName", c => c.String(unicode: false));
            AddColumn("dbo.Boats", "BoatModel", c => c.String(unicode: false));
            AddColumn("dbo.Boats", "Length", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Boats", "Beam", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Boats", "Weight", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Engines", "TypeOfEngine", c => c.Int(nullable: false));
            AddColumn("dbo.Engines", "TypeOfFuel", c => c.Int(nullable: false));
            AddColumn("dbo.Subjects", "AdvertName", c => c.String(unicode: false));
            AddColumn("dbo.Subjects", "AdvertDescription", c => c.String(unicode: false));
            AddColumn("dbo.SailBoat", "YachtType", c => c.String(unicode: false));
            AddColumn("dbo.SailBoat", "RudderType", c => c.String(unicode: false));
            AlterColumn("dbo.Boats", "BuiltYear", c => c.String(unicode: false));
            DropColumn("dbo.Adverts", "Mail");
            DropColumn("dbo.Boats", "BrandName");
            DropColumn("dbo.Boats", "Lenght");
            DropColumn("dbo.Engines", "Type");
            DropColumn("dbo.Engines", "FuelType");
            DropColumn("dbo.Subjects", "Name");
            DropColumn("dbo.Subjects", "Description");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Subjects", "Description", c => c.String(unicode: false));
            AddColumn("dbo.Subjects", "Name", c => c.String(unicode: false));
            AddColumn("dbo.Engines", "FuelType", c => c.String(unicode: false));
            AddColumn("dbo.Engines", "Type", c => c.String(unicode: false));
            AddColumn("dbo.Boats", "Lenght", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Boats", "BrandName", c => c.String(unicode: false));
            AddColumn("dbo.Adverts", "Mail", c => c.String(unicode: false));
            DropForeignKey("dbo.SubjectImages", "Subject_SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.SubjectImages", new[] { "Subject_SubjectId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            AlterColumn("dbo.Boats", "BuiltYear", c => c.DateTime(nullable: false));
            DropColumn("dbo.SailBoat", "RudderType");
            DropColumn("dbo.SailBoat", "YachtType");
            DropColumn("dbo.Subjects", "AdvertDescription");
            DropColumn("dbo.Subjects", "AdvertName");
            DropColumn("dbo.Engines", "TypeOfFuel");
            DropColumn("dbo.Engines", "TypeOfEngine");
            DropColumn("dbo.Boats", "Weight");
            DropColumn("dbo.Boats", "Beam");
            DropColumn("dbo.Boats", "Length");
            DropColumn("dbo.Boats", "BoatModel");
            DropColumn("dbo.Boats", "ProducentName");
            DropColumn("dbo.Adverts", "AdditionalInformation");
            DropColumn("dbo.Adverts", "City");
            DropColumn("dbo.Adverts", "Email");
            DropColumn("dbo.Adverts", "SureName");
            DropColumn("dbo.Adverts", "Name");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.SubjectImages");
            DropTable("dbo.DicYearbooks");
            DropTable("dbo.DicCatogories");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetRoles");
        }
    }
}
