namespace Sangha.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedForeignKeyToRetreatTeacher : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TeacherRetreat", "Teacher_TeacherId", "dbo.Teacher");
            DropForeignKey("dbo.TeacherRetreat", "Retreat_RetreatId", "dbo.Retreat");
            DropIndex("dbo.TeacherRetreat", new[] { "Teacher_TeacherId" });
            DropIndex("dbo.TeacherRetreat", new[] { "Retreat_RetreatId" });
            DropColumn("dbo.Retreat", "TeacherId");
            DropTable("dbo.TeacherRetreat");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.TeacherRetreat",
                c => new
                    {
                        Teacher_TeacherId = c.Int(nullable: false),
                        Retreat_RetreatId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Teacher_TeacherId, t.Retreat_RetreatId });
            
            AddColumn("dbo.Retreat", "TeacherId", c => c.Int());
            CreateIndex("dbo.TeacherRetreat", "Retreat_RetreatId");
            CreateIndex("dbo.TeacherRetreat", "Teacher_TeacherId");
            AddForeignKey("dbo.TeacherRetreat", "Retreat_RetreatId", "dbo.Retreat", "RetreatId", cascadeDelete: true);
            AddForeignKey("dbo.TeacherRetreat", "Teacher_TeacherId", "dbo.Teacher", "TeacherId", cascadeDelete: true);
        }
    }
}
