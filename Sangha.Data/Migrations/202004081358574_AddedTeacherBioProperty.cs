namespace Sangha.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTeacherBioProperty : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Teacher", "Bio", c => c.String(maxLength: 1000));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Teacher", "Bio");
        }
    }
}
