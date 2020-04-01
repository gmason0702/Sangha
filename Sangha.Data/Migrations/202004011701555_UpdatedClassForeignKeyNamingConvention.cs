namespace Sangha.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedClassForeignKeyNamingConvention : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Retreat", "TeacherId", c => c.Int());
            AddColumn("dbo.Teacher", "Retreat_RetreatId", c => c.Int());
            CreateIndex("dbo.Teacher", "Retreat_RetreatId");
            AddForeignKey("dbo.Teacher", "Retreat_RetreatId", "dbo.Retreat", "RetreatId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Teacher", "Retreat_RetreatId", "dbo.Retreat");
            DropIndex("dbo.Teacher", new[] { "Retreat_RetreatId" });
            DropColumn("dbo.Teacher", "Retreat_RetreatId");
            DropColumn("dbo.Retreat", "TeacherId");
        }
    }
}
