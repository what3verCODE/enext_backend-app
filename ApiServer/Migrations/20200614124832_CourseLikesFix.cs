using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiServer.Migrations
{
    public partial class CourseLikesFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserCourseLikesEntity_Courses_CourseId",
                table: "UserCourseLikesEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCourseLikesEntity_AspNetUsers_UserId",
                table: "UserCourseLikesEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserCourseLikesEntity",
                table: "UserCourseLikesEntity");

            migrationBuilder.RenameTable(
                name: "UserCourseLikesEntity",
                newName: "CoursesLikes");

            migrationBuilder.RenameIndex(
                name: "IX_UserCourseLikesEntity_UserId",
                table: "CoursesLikes",
                newName: "IX_CoursesLikes_UserId");

            migrationBuilder.AddColumn<int>(
                name: "Attempts",
                table: "Progresses",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CoursesLikes",
                table: "CoursesLikes",
                columns: new[] { "CourseId", "UserId" });

            migrationBuilder.AddForeignKey(
                name: "FK_CoursesLikes_Courses_CourseId",
                table: "CoursesLikes",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CoursesLikes_AspNetUsers_UserId",
                table: "CoursesLikes",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CoursesLikes_Courses_CourseId",
                table: "CoursesLikes");

            migrationBuilder.DropForeignKey(
                name: "FK_CoursesLikes_AspNetUsers_UserId",
                table: "CoursesLikes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CoursesLikes",
                table: "CoursesLikes");

            migrationBuilder.DropColumn(
                name: "Attempts",
                table: "Progresses");

            migrationBuilder.RenameTable(
                name: "CoursesLikes",
                newName: "UserCourseLikesEntity");

            migrationBuilder.RenameIndex(
                name: "IX_CoursesLikes_UserId",
                table: "UserCourseLikesEntity",
                newName: "IX_UserCourseLikesEntity_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserCourseLikesEntity",
                table: "UserCourseLikesEntity",
                columns: new[] { "CourseId", "UserId" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserCourseLikesEntity_Courses_CourseId",
                table: "UserCourseLikesEntity",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserCourseLikesEntity_AspNetUsers_UserId",
                table: "UserCourseLikesEntity",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
