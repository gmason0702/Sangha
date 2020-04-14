namespace Sangha.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixedMigrations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Center",
                c => new
                    {
                        CenterId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        City = c.String(),
                        State = c.Int(nullable: false),
                        Country = c.String(),
                    })
                .PrimaryKey(t => t.CenterId);
            
            CreateTable(
                "dbo.Rating",
                c => new
                    {
                        RatingId = c.Int(nullable: false, identity: true),
                        MyRating = c.Int(nullable: false),
                        Description = c.String(),
                        UserId = c.String(maxLength: 128),
                        VisitDate = c.DateTime(),
                        CenterId = c.Int(),
                        RetreatId = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.RatingId)
                .ForeignKey("dbo.Center", t => t.CenterId)
                .ForeignKey("dbo.Retreat", t => t.RetreatId)
                .ForeignKey("dbo.ApplicationUser", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.CenterId)
                .Index(t => t.RetreatId);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                        IdentityRole_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id);
            
            CreateTable(
                "dbo.Retreat",
                c => new
                    {
                        RetreatId = c.Int(nullable: false, identity: true),
                        RetreatName = c.String(),
                        RetreatDate = c.DateTime(nullable: false),
                        RetreatLength = c.Int(nullable: false),
                        Description = c.String(),
                        CenterId = c.Int(),
                    })
                .PrimaryKey(t => t.RetreatId)
                .ForeignKey("dbo.Center", t => t.CenterId)
                .Index(t => t.CenterId);
            
            CreateTable(
                "dbo.Talk",
                c => new
                    {
                        TalkId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                        Topic = c.String(),
                        IsGuided = c.Boolean(nullable: false),
                        TalkLength = c.Time(nullable: false, precision: 7),
                        TalkDate = c.DateTime(nullable: false),
                        IsStarred = c.Boolean(nullable: false),
                        TalkLink = c.String(),
                        TeacherLinkId = c.Int(nullable: false),
                        TalkLinkId = c.Int(nullable: false),
                        TeacherId = c.Int(),
                        RetreatId = c.Int(),
                        CenterId = c.Int(),
                    })
                .PrimaryKey(t => t.TalkId)
                .ForeignKey("dbo.Center", t => t.CenterId)
                .ForeignKey("dbo.Retreat", t => t.RetreatId)
                .ForeignKey("dbo.Teacher", t => t.TeacherId)
                .Index(t => t.TeacherId)
                .Index(t => t.RetreatId)
                .Index(t => t.CenterId);
            
            CreateTable(
                "dbo.Teacher",
                c => new
                    {
                        TeacherId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Bio = c.String(maxLength: 1000),
                    })
                .PrimaryKey(t => t.TeacherId);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SitTracker",
                c => new
                    {
                        SitId = c.Int(nullable: false, identity: true),
                        SitDate = c.DateTimeOffset(nullable: false, precision: 7),
                        SitLength = c.Time(nullable: false, precision: 7),
                        Note = c.String(),
                        SitLink = c.String(),
                        TypeOfSit = c.Int(nullable: false),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.SitId)
                .ForeignKey("dbo.ApplicationUser", t => t.UserId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SitTracker", "UserId", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.Rating", "UserId", "dbo.ApplicationUser");
            DropForeignKey("dbo.Talk", "TeacherId", "dbo.Teacher");
            DropForeignKey("dbo.Talk", "RetreatId", "dbo.Retreat");
            DropForeignKey("dbo.Talk", "CenterId", "dbo.Center");
            DropForeignKey("dbo.Rating", "RetreatId", "dbo.Retreat");
            DropForeignKey("dbo.Retreat", "CenterId", "dbo.Center");
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.Rating", "CenterId", "dbo.Center");
            DropIndex("dbo.SitTracker", new[] { "UserId" });
            DropIndex("dbo.Talk", new[] { "CenterId" });
            DropIndex("dbo.Talk", new[] { "RetreatId" });
            DropIndex("dbo.Talk", new[] { "TeacherId" });
            DropIndex("dbo.Retreat", new[] { "CenterId" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Rating", new[] { "RetreatId" });
            DropIndex("dbo.Rating", new[] { "CenterId" });
            DropIndex("dbo.Rating", new[] { "UserId" });
            DropTable("dbo.SitTracker");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.Teacher");
            DropTable("dbo.Talk");
            DropTable("dbo.Retreat");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.Rating");
            DropTable("dbo.Center");
        }
    }
}
