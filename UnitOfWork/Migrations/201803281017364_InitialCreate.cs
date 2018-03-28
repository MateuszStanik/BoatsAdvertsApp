namespace UnitOfWork.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Adverts",
                c => new
                    {
                        AdvertId = c.Long(nullable: false, identity: true),
                        AdditionDate = c.DateTime(),
                        FinishDate = c.DateTime(),
                        Name = c.String(unicode: false),
                        SureName = c.String(unicode: false),
                        PhoneNumber = c.String(unicode: false),
                        Email = c.String(unicode: false),
                        City = c.String(unicode: false),
                        AdditionalInformation = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.AdvertId);
            
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
                "dbo.Subjects",
                c => new
                    {
                        SubjectId = c.Long(nullable: false, identity: true),
                        AdvertId = c.Long(nullable: false),
                        CategoryId = c.Long(nullable: false),
                        AdvertName = c.String(unicode: false),
                        AdvertDescription = c.String(unicode: false),
                        Price = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.SubjectId)
                .ForeignKey("dbo.Adverts", t => t.AdvertId, cascadeDelete: true)
                .Index(t => t.AdvertId);
            
            CreateTable(
                "dbo.MotorBoat",
                c => new
                    {
                        SubjectId = c.Long(nullable: false),
                        EnginePower = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MotorboatType = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.SubjectId)
                .ForeignKey("dbo.Boats", t => t.SubjectId)
                .Index(t => t.SubjectId);
            
            CreateTable(
                "dbo.SailBoat",
                c => new
                    {
                        SubjectId = c.Long(nullable: false),
                        SailsArea = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsEngine = c.Boolean(nullable: false),
                        EnginePower = c.Decimal(nullable: false, precision: 18, scale: 2),
                        EngineType = c.Byte(nullable: false),
                        HullType = c.String(unicode: false),
                        YachtType = c.String(unicode: false),
                        RudderType = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.SubjectId)
                .ForeignKey("dbo.Boats", t => t.SubjectId)
                .Index(t => t.SubjectId);
            
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
                        SubjectId = c.Long(nullable: false),
                        Name = c.String(unicode: false),
                        Identifier = c.Guid(nullable: false),
                        ImageData = c.Binary(),
                    })
                .PrimaryKey(t => t.ImageID)
                .ForeignKey("dbo.Subjects", t => t.SubjectId, cascadeDelete: true)
                .Index(t => t.SubjectId);
            
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
            
            CreateTable(
                "dbo.Boats",
                c => new
                    {
                        SubjectId = c.Long(nullable: false),
                        ProducentName = c.String(unicode: false),
                        BoatModel = c.String(unicode: false),
                        Length = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Beam = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Weight = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BuiltYear = c.String(unicode: false),
                        Draft = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Displacement = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.SubjectId)
                .ForeignKey("dbo.Subjects", t => t.SubjectId)
                .Index(t => t.SubjectId);
            
            CreateTable(
                "dbo.Engines",
                c => new
                    {
                        SubjectId = c.Long(nullable: false),
                        Brand = c.String(unicode: false),
                        Power = c.Double(nullable: false),
                        TypeOfEngine = c.Int(nullable: false),
                        TypeOfFuel = c.Int(nullable: false),
                        BuiltYear = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.SubjectId)
                .ForeignKey("dbo.Subjects", t => t.SubjectId)
                .Index(t => t.SubjectId);
            
            CreateTable(
                "dbo.Sails",
                c => new
                    {
                        SubjectId = c.Long(nullable: false),
                        LeechLenght = c.Double(nullable: false),
                        FootLenght = c.Double(nullable: false),
                        LuffLenght = c.Double(nullable: false),
                        Brand = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.SubjectId)
                .ForeignKey("dbo.Subjects", t => t.SubjectId)
                .Index(t => t.SubjectId);
            
            CreateTable(
                "dbo.Trailors",
                c => new
                    {
                        SubjectId = c.Long(nullable: false),
                        Weight = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Length = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Width = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Capcity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Brand = c.String(unicode: false),
                        BuiltYear = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.SubjectId)
                .ForeignKey("dbo.Subjects", t => t.SubjectId)
                .Index(t => t.SubjectId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Trailors", "SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.Sails", "SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.Engines", "SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.Boats", "SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.SubjectImages", "SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.Subjects", "AdvertId", "dbo.Adverts");
            DropForeignKey("dbo.SailBoat", "SubjectId", "dbo.Boats");
            DropForeignKey("dbo.MotorBoat", "SubjectId", "dbo.Boats");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Trailors", new[] { "SubjectId" });
            DropIndex("dbo.Sails", new[] { "SubjectId" });
            DropIndex("dbo.Engines", new[] { "SubjectId" });
            DropIndex("dbo.Boats", new[] { "SubjectId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.SubjectImages", new[] { "SubjectId" });
            DropIndex("dbo.SailBoat", new[] { "SubjectId" });
            DropIndex("dbo.MotorBoat", new[] { "SubjectId" });
            DropIndex("dbo.Subjects", new[] { "AdvertId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropTable("dbo.Trailors");
            DropTable("dbo.Sails");
            DropTable("dbo.Engines");
            DropTable("dbo.Boats");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.SubjectImages");
            DropTable("dbo.DicYearbooks");
            DropTable("dbo.DicCatogories");
            DropTable("dbo.SailBoat");
            DropTable("dbo.MotorBoat");
            DropTable("dbo.Subjects");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Adverts");
        }
    }
}
