namespace Sangha.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixedTables : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TeacherCenter", "Teacher_TeacherId", "dbo.Teacher");
            DropForeignKey("dbo.TeacherCenter", "Center_CenterId", "dbo.Center");
            DropForeignKey("dbo.TeacherRetreat", "Teacher_TeacherId", "dbo.Teacher");
            DropForeignKey("dbo.TeacherRetreat", "Retreat_RetreatId", "dbo.Retreat");
            DropIndex("dbo.TeacherCenter", new[] { "Teacher_TeacherId" });
            DropIndex("dbo.TeacherCenter", new[] { "Center_CenterId" });
            DropIndex("dbo.TeacherRetreat", new[] { "Teacher_TeacherId" });
            DropIndex("dbo.TeacherRetreat", new[] { "Retreat_RetreatId" });
            DropTable("dbo.TeacherCenter");
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
            
            CreateTable(
                "dbo.TeacherCenter",
                c => new
                    {
                        Teacher_TeacherId = c.Int(nullable: false),
                        Center_CenterId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Teacher_TeacherId, t.Center_CenterId });
            
            CreateIndex("dbo.TeacherRetreat", "Retreat_RetreatId");
            CreateIndex("dbo.TeacherRetreat", "Teacher_TeacherId");
            CreateIndex("dbo.TeacherCenter", "Center_CenterId");
            CreateIndex("dbo.TeacherCenter", "Teacher_TeacherId");
            AddForeignKey("dbo.TeacherRetreat", "Retreat_RetreatId", "dbo.Retreat", "RetreatId", cascadeDelete: true);
            AddForeignKey("dbo.TeacherRetreat", "Teacher_TeacherId", "dbo.Teacher", "TeacherId", cascadeDelete: true);
            AddForeignKey("dbo.TeacherCenter", "Center_CenterId", "dbo.Center", "CenterId", cascadeDelete: true);
            AddForeignKey("dbo.TeacherCenter", "Teacher_TeacherId", "dbo.Teacher", "TeacherId", cascadeDelete: true);
        }
    }
}
