namespace Sangha.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NotSureWhyImHavingToMigrateHere : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Talk", "TalkLink", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Talk", "TalkLink");
        }
    }
}
