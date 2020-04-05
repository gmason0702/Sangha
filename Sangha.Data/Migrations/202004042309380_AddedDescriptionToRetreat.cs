namespace Sangha.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDescriptionToRetreat : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Retreat", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Retreat", "Description");
        }
    }
}
