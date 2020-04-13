namespace Sangha.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedICollectionReteratToTeacher : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Teacher", "Retreat_RetreatId", "dbo.Retreat");
            DropIndex("dbo.Teacher", new[] { "Retreat_RetreatId" });
            CreateTable(
                "dbo.TeacherRetreat",
                c => new
                    {
                        Teacher_TeacherId = c.Int(nullable: false),
                        Retreat_RetreatId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Teacher_TeacherId, t.Retreat_RetreatId })
                .ForeignKey("dbo.Teacher", t => t.Teacher_TeacherId, cascadeDelete: true)
                .ForeignKey("dbo.Retreat", t => t.Retreat_RetreatId, cascadeDelete: true)
                .Index(t => t.Teacher_TeacherId)
                .Index(t => t.Retreat_RetreatId);
            
            DropColumn("dbo.Teacher", "Retreat_RetreatId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Teacher", "Retreat_RetreatId", c => c.Int());
            DropForeignKey("dbo.TeacherRetreat", "Retreat_RetreatId", "dbo.Retreat");
            DropForeignKey("dbo.TeacherRetreat", "Teacher_TeacherId", "dbo.Teacher");
            DropIndex("dbo.TeacherRetreat", new[] { "Retreat_RetreatId" });
            DropIndex("dbo.TeacherRetreat", new[] { "Teacher_TeacherId" });
            DropTable("dbo.TeacherRetreat");
            CreateIndex("dbo.Teacher", "Retreat_RetreatId");
            AddForeignKey("dbo.Teacher", "Retreat_RetreatId", "dbo.Retreat", "RetreatId");
        }
    }
}
