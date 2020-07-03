using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiServer.Migrations
{
    public partial class LastVisitedFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_LastVisitedLessons",
                table: "LastVisitedLessons");

            migrationBuilder.DropColumn(
                name: "LastVisitedLessonId",
                table: "LastVisitedLessons");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LastVisitedLessons",
                table: "LastVisitedLessons",
                columns: new[] { "UserId", "CourseId", "LessonId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_LastVisitedLessons",
                table: "LastVisitedLessons");

            migrationBuilder.AddColumn<long>(
                name: "LastVisitedLessonId",
                table: "LastVisitedLessons",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddPrimaryKey(
                name: "PK_LastVisitedLessons",
                table: "LastVisitedLessons",
                columns: new[] { "UserId", "CourseId", "LastVisitedLessonId" });
        }
    }
}
