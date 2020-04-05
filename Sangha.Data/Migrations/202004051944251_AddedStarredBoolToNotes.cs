namespace Sangha.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedStarredBoolToNotes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Talk", "IsStarred", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Talk", "IsStarred");
        }
    }
}
