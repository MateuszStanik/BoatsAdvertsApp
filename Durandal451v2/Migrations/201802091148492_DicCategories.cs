namespace Durandal451v2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DicCategories : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Logins", "UserId", "dbo.Users");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Logins", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropPrimaryKey("dbo.AspNetRoles");
            DropPrimaryKey("dbo.AspNetUserRoles");
            DropPrimaryKey("dbo.AspNetUsers");
            DropPrimaryKey("dbo.AspNetUserLogins");
            AlterColumn("dbo.AspNetRoles", "Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.AspNetRoles", "Name", c => c.String(nullable: false, maxLength: 256));
            AlterColumn("dbo.AspNetUserRoles", "UserId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.AspNetUserRoles", "RoleId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.AspNetUsers", "Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.AspNetUsers", "Email", c => c.String(maxLength: 256));
            AlterColumn("dbo.AspNetUsers", "PasswordHash", c => c.String());
            AlterColumn("dbo.AspNetUsers", "SecurityStamp", c => c.String());
            AlterColumn("dbo.AspNetUsers", "PhoneNumber", c => c.String());
            AlterColumn("dbo.AspNetUsers", "UserName", c => c.String(nullable: false, maxLength: 256));
            AlterColumn("dbo.AspNetUserClaims", "UserId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.AspNetUserClaims", "ClaimType", c => c.String());
            AlterColumn("dbo.AspNetUserClaims", "ClaimValue", c => c.String());
            AlterColumn("dbo.AspNetUserLogins", "LoginProvider", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.AspNetUserLogins", "ProviderKey", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.AspNetUserLogins", "UserId", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.AspNetRoles", "Id");
            AddPrimaryKey("dbo.AspNetUserRoles", new[] { "UserId", "RoleId" });
            AddPrimaryKey("dbo.AspNetUsers", "Id");
            AddPrimaryKey("dbo.AspNetUserLogins", new[] { "LoginProvider", "ProviderKey", "UserId" });
            CreateIndex("dbo.AspNetRoles", "Name", unique: true, name: "RoleNameIndex");
            CreateIndex("dbo.AspNetUserRoles", "UserId");
            CreateIndex("dbo.AspNetUserRoles", "RoleId");
            CreateIndex("dbo.AspNetUsers", "UserName", unique: true, name: "UserNameIndex");
            CreateIndex("dbo.AspNetUserClaims", "UserId");
            CreateIndex("dbo.AspNetUserLogins", "UserId");
            AddForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            DropTable("dbo.Logins");
            DropTable("dbo.Users");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                        Surname = c.String(unicode: false),
                        PhoneNumber = c.String(unicode: false),
                        City = c.String(unicode: false),
                        Street = c.String(unicode: false),
                        PostalCode = c.String(unicode: false),
                        HouseNumber = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.Logins",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        Email = c.String(unicode: false),
                        Password = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.UserId);
            
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropPrimaryKey("dbo.AspNetUserLogins");
            DropPrimaryKey("dbo.AspNetUsers");
            DropPrimaryKey("dbo.AspNetUserRoles");
            DropPrimaryKey("dbo.AspNetRoles");
            AlterColumn("dbo.AspNetUserLogins", "UserId", c => c.String(nullable: false, maxLength: 128, unicode: false));
            AlterColumn("dbo.AspNetUserLogins", "ProviderKey", c => c.String(nullable: false, maxLength: 128, unicode: false));
            AlterColumn("dbo.AspNetUserLogins", "LoginProvider", c => c.String(nullable: false, maxLength: 128, unicode: false));
            AlterColumn("dbo.AspNetUserClaims", "ClaimValue", c => c.String(unicode: false));
            AlterColumn("dbo.AspNetUserClaims", "ClaimType", c => c.String(unicode: false));
            AlterColumn("dbo.AspNetUserClaims", "UserId", c => c.String(nullable: false, maxLength: 128, unicode: false));
            AlterColumn("dbo.AspNetUsers", "UserName", c => c.String(nullable: false, maxLength: 256, unicode: false));
            AlterColumn("dbo.AspNetUsers", "PhoneNumber", c => c.String(unicode: false));
            AlterColumn("dbo.AspNetUsers", "SecurityStamp", c => c.String(unicode: false));
            AlterColumn("dbo.AspNetUsers", "PasswordHash", c => c.String(unicode: false));
            AlterColumn("dbo.AspNetUsers", "Email", c => c.String(maxLength: 256, unicode: false));
            AlterColumn("dbo.AspNetUsers", "Id", c => c.String(nullable: false, maxLength: 128, unicode: false));
            AlterColumn("dbo.AspNetUserRoles", "RoleId", c => c.String(nullable: false, maxLength: 128, unicode: false));
            AlterColumn("dbo.AspNetUserRoles", "UserId", c => c.String(nullable: false, maxLength: 128, unicode: false));
            AlterColumn("dbo.AspNetRoles", "Name", c => c.String(nullable: false, maxLength: 256, unicode: false));
            AlterColumn("dbo.AspNetRoles", "Id", c => c.String(nullable: false, maxLength: 128, unicode: false));
            AddPrimaryKey("dbo.AspNetUserLogins", new[] { "LoginProvider", "ProviderKey", "UserId" });
            AddPrimaryKey("dbo.AspNetUsers", "Id");
            AddPrimaryKey("dbo.AspNetUserRoles", new[] { "UserId", "RoleId" });
            AddPrimaryKey("dbo.AspNetRoles", "Id");
            CreateIndex("dbo.AspNetUserLogins", "UserId");
            CreateIndex("dbo.AspNetUserClaims", "UserId");
            CreateIndex("dbo.AspNetUsers", "UserName", unique: true, name: "UserNameIndex");
            CreateIndex("dbo.AspNetUserRoles", "RoleId");
            CreateIndex("dbo.AspNetUserRoles", "UserId");
            CreateIndex("dbo.AspNetRoles", "Name", unique: true, name: "RoleNameIndex");
            CreateIndex("dbo.Logins", "UserId");
            AddForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Logins", "UserId", "dbo.Users", "UserId");
        }
    }
}
