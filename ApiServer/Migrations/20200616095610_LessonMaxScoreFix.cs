using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiServer.Migrations
{
    public partial class LessonMaxScoreFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserLessonLikesEntity_Lessons_LessonId",
                table: "UserLessonLikesEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLessonLikesEntity_AspNetUsers_UserId",
                table: "UserLessonLikesEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserLessonLikesEntity",
                table: "UserLessonLikesEntity");

            migrationBuilder.RenameTable(
                name: "UserLessonLikesEntity",
                newName: "LessonsLikes");

            migrationBuilder.RenameIndex(
                name: "IX_UserLessonLikesEntity_UserId",
                table: "LessonsLikes",
                newName: "IX_LessonsLikes_UserId");

            migrationBuilder.AddColumn<int>(
                name: "MaxScore",
                table: "Lessons",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_LessonsLikes",
                table: "LessonsLikes",
                columns: new[] { "LessonId", "UserId" });

            migrationBuilder.AddForeignKey(
                name: "FK_LessonsLikes_Lessons_LessonId",
                table: "LessonsLikes",
                column: "LessonId",
                principalTable: "Lessons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LessonsLikes_AspNetUsers_UserId",
                table: "LessonsLikes",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LessonsLikes_Lessons_LessonId",
                table: "LessonsLikes");

            migrationBuilder.DropForeignKey(
                name: "FK_LessonsLikes_AspNetUsers_UserId",
                table: "LessonsLikes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LessonsLikes",
                table: "LessonsLikes");

            migrationBuilder.DropColumn(
                name: "MaxScore",
                table: "Lessons");

            migrationBuilder.RenameTable(
                name: "LessonsLikes",
                newName: "UserLessonLikesEntity");

            migrationBuilder.RenameIndex(
                name: "IX_LessonsLikes_UserId",
                table: "UserLessonLikesEntity",
                newName: "IX_UserLessonLikesEntity_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserLessonLikesEntity",
                table: "UserLessonLikesEntity",
                columns: new[] { "LessonId", "UserId" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserLessonLikesEntity_Lessons_LessonId",
                table: "UserLessonLikesEntity",
                column: "LessonId",
                principalTable: "Lessons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserLessonLikesEntity_AspNetUsers_UserId",
                table: "UserLessonLikesEntity",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
