using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiServer.Migrations
{
    public partial class LastVisitedFix2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_LastVisitedLessons",
                table: "LastVisitedLessons");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LastVisitedLessons",
                table: "LastVisitedLessons",
                columns: new[] { "UserId", "CourseId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_LastVisitedLessons",
                table: "LastVisitedLessons");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LastVisitedLessons",
                table: "LastVisitedLessons",
                columns: new[] { "UserId", "CourseId", "LessonId" });
        }
    }
}
