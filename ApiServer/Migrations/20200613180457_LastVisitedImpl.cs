using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiServer.Migrations
{
    public partial class LastVisitedImpl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Likes",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "Likes",
                table: "Courses");

            migrationBuilder.AddColumn<int>(
                name: "MaxAttempts",
                table: "Quizzes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "LastVisitedLessons",
                columns: table => new
                {
                    CourseId = table.Column<long>(nullable: false),
                    UserId = table.Column<string>(nullable: false),
                    LastVisitedLessonId = table.Column<long>(nullable: false),
                    LessonId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LastVisitedLessons", x => new { x.UserId, x.CourseId, x.LastVisitedLessonId });
                    table.ForeignKey(
                        name: "FK_LastVisitedLessons_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LastVisitedLessons_Lessons_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Lessons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LastVisitedLessons_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LastVisitedLessons_CourseId",
                table: "LastVisitedLessons",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_LastVisitedLessons_LessonId",
                table: "LastVisitedLessons",
                column: "LessonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LastVisitedLessons");

            migrationBuilder.DropColumn(
                name: "MaxAttempts",
                table: "Quizzes");

            migrationBuilder.AddColumn<long>(
                name: "Likes",
                table: "Lessons",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "Likes",
                table: "Courses",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
