namespace Sangha.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedSitTrackerTypeOfSitEnum : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SitTracker", "TypeOfSit", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SitTracker", "TypeOfSit");
        }
    }
}
