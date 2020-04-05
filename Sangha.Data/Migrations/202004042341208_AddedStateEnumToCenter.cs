namespace Sangha.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedStateEnumToCenter : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Center", "State", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Center", "State", c => c.String());
        }
    }
}
