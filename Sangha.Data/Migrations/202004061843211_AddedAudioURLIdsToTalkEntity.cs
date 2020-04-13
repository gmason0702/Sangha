namespace Sangha.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedAudioURLIdsToTalkEntity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Talk", "TeacherLinkId", c => c.Int(nullable: false));
            AddColumn("dbo.Talk", "TalkLinkId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Talk", "TalkLinkId");
            DropColumn("dbo.Talk", "TeacherLinkId");
        }
    }
}
