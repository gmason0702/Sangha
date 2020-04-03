namespace Sangha.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedDateTimeAttributes : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Retreat", "RetreatDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Retreat", "RetreatDate", c => c.DateTimeOffset(nullable: false, precision: 7));
        }
    }
}
