namespace Sangha.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedRatingModelsServices : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Center", "AvgRating");
            DropColumn("dbo.Retreat", "AvgRating");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Retreat", "AvgRating", c => c.Double(nullable: false));
            AddColumn("dbo.Center", "AvgRating", c => c.Double(nullable: false));
        }
    }
}
