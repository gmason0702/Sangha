namespace Sangha.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedSitTrackerClassModelsServiceControllerViews : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SitTracker",
                c => new
                    {
                        SitId = c.Int(nullable: false, identity: true),
                        SitDate = c.DateTimeOffset(nullable: false, precision: 7),
                        SitLength = c.Time(nullable: false, precision: 7),
                        Note = c.String(),
                        SitLink = c.String(),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.SitId)
                .ForeignKey("dbo.ApplicationUser", t => t.UserId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SitTracker", "UserId", "dbo.ApplicationUser");
            DropIndex("dbo.SitTracker", new[] { "UserId" });
            DropTable("dbo.SitTracker");
        }
    }
}
