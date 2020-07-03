using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiServer.Migrations
{
    public partial class AuthAndProgressImpl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommentEntity_AspNetUsers_AuthorId",
                table: "CommentEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_CommentEntity_Lessons_LessonId",
                table: "CommentEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_CommentEntity_CommentEntity_RootCommentId",
                table: "CommentEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_ProgressEntity_Lessons_LessonId",
                table: "ProgressEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_ProgressEntity_UserProgressEntity_UserProgressUserId_UserPr~",
                table: "ProgressEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCommentLikesEntity_CommentEntity_CommentId",
                table: "UserCommentLikesEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCourseEntity_Courses_CourseId",
                table: "UserCourseEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCourseEntity_AspNetUsers_SubscriberId",
                table: "UserCourseEntity");

            migrationBuilder.DropTable(
                name: "UserProgressEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserCourseEntity",
                table: "UserCourseEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProgressEntity",
                table: "ProgressEntity");

            migrationBuilder.DropIndex(
                name: "IX_ProgressEntity_UserProgressUserId_UserProgressCourseId",
                table: "ProgressEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CommentEntity",
                table: "CommentEntity");

            migrationBuilder.DropColumn(
                name: "ManualChecking",
                table: "ProgressEntity");

            migrationBuilder.DropColumn(
                name: "UserProgressCourseId",
                table: "ProgressEntity");

            migrationBuilder.DropColumn(
                name: "UserProgressUserId",
                table: "ProgressEntity");

            migrationBuilder.RenameTable(
                name: "UserCourseEntity",
                newName: "Subscriptions");

            migrationBuilder.RenameTable(
                name: "ProgressEntity",
                newName: "Progresses");

            migrationBuilder.RenameTable(
                name: "CommentEntity",
                newName: "Comments");

            migrationBuilder.RenameIndex(
                name: "IX_UserCourseEntity_CourseId",
                table: "Subscriptions",
                newName: "IX_Subscriptions_CourseId");

            migrationBuilder.RenameIndex(
                name: "IX_ProgressEntity_LessonId",
                table: "Progresses",
                newName: "IX_Progresses_LessonId");

            migrationBuilder.RenameIndex(
                name: "IX_CommentEntity_RootCommentId",
                table: "Comments",
                newName: "IX_Comments_RootCommentId");

            migrationBuilder.RenameIndex(
                name: "IX_CommentEntity_LessonId",
                table: "Comments",
                newName: "IX_Comments_LessonId");

            migrationBuilder.RenameIndex(
                name: "IX_CommentEntity_AuthorId",
                table: "Comments",
                newName: "IX_Comments_AuthorId");

            migrationBuilder.AlterColumn<int>(
                name: "Score",
                table: "Progresses",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<long>(
                name: "CourseId",
                table: "Progresses",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<bool>(
                name: "IsVisited",
                table: "Progresses",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ManuallyChecked",
                table: "Progresses",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Progresses",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Subscriptions",
                table: "Subscriptions",
                columns: new[] { "SubscriberId", "CourseId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Progresses",
                table: "Progresses",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comments",
                table: "Comments",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                columns: table => new
                {
                    Token = table.Column<string>(nullable: false),
                    JwtId = table.Column<string>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    ExpiryDate = table.Column<DateTime>(nullable: false),
                    Used = table.Column<bool>(nullable: false),
                    Invalidated = table.Column<bool>(nullable: false),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.Token);
                    table.ForeignKey(
                        name: "FK_RefreshTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Progresses_CourseId",
                table: "Progresses",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Progresses_UserId",
                table: "Progresses",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_UserId",
                table: "RefreshTokens",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_AuthorId",
                table: "Comments",
                column: "AuthorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Lessons_LessonId",
                table: "Comments",
                column: "LessonId",
                principalTable: "Lessons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Comments_RootCommentId",
                table: "Comments",
                column: "RootCommentId",
                principalTable: "Comments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Progresses_Courses_CourseId",
                table: "Progresses",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Progresses_Lessons_LessonId",
                table: "Progresses",
                column: "LessonId",
                principalTable: "Lessons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Progresses_AspNetUsers_UserId",
                table: "Progresses",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Subscriptions_Courses_CourseId",
                table: "Subscriptions",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Subscriptions_AspNetUsers_SubscriberId",
                table: "Subscriptions",
                column: "SubscriberId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserCommentLikesEntity_Comments_CommentId",
                table: "UserCommentLikesEntity",
                column: "CommentId",
                principalTable: "Comments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_AuthorId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Lessons_LessonId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Comments_RootCommentId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Progresses_Courses_CourseId",
                table: "Progresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Progresses_Lessons_LessonId",
                table: "Progresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Progresses_AspNetUsers_UserId",
                table: "Progresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Subscriptions_Courses_CourseId",
                table: "Subscriptions");

            migrationBuilder.DropForeignKey(
                name: "FK_Subscriptions_AspNetUsers_SubscriberId",
                table: "Subscriptions");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCommentLikesEntity_Comments_CommentId",
                table: "UserCommentLikesEntity");

            migrationBuilder.DropTable(
                name: "RefreshTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Subscriptions",
                table: "Subscriptions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Progresses",
                table: "Progresses");

            migrationBuilder.DropIndex(
                name: "IX_Progresses_CourseId",
                table: "Progresses");

            migrationBuilder.DropIndex(
                name: "IX_Progresses_UserId",
                table: "Progresses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comments",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "Progresses");

            migrationBuilder.DropColumn(
                name: "IsVisited",
                table: "Progresses");

            migrationBuilder.DropColumn(
                name: "ManuallyChecked",
                table: "Progresses");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Progresses");

            migrationBuilder.RenameTable(
                name: "Subscriptions",
                newName: "UserCourseEntity");

            migrationBuilder.RenameTable(
                name: "Progresses",
                newName: "ProgressEntity");

            migrationBuilder.RenameTable(
                name: "Comments",
                newName: "CommentEntity");

            migrationBuilder.RenameIndex(
                name: "IX_Subscriptions_CourseId",
                table: "UserCourseEntity",
                newName: "IX_UserCourseEntity_CourseId");

            migrationBuilder.RenameIndex(
                name: "IX_Progresses_LessonId",
                table: "ProgressEntity",
                newName: "IX_ProgressEntity_LessonId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_RootCommentId",
                table: "CommentEntity",
                newName: "IX_CommentEntity_RootCommentId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_LessonId",
                table: "CommentEntity",
                newName: "IX_CommentEntity_LessonId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_AuthorId",
                table: "CommentEntity",
                newName: "IX_CommentEntity_AuthorId");

            migrationBuilder.AlterColumn<int>(
                name: "Score",
                table: "ProgressEntity",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldDefaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "ManualChecking",
                table: "ProgressEntity",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "UserProgressCourseId",
                table: "ProgressEntity",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "UserProgressUserId",
                table: "ProgressEntity",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserCourseEntity",
                table: "UserCourseEntity",
                columns: new[] { "SubscriberId", "CourseId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProgressEntity",
                table: "ProgressEntity",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CommentEntity",
                table: "CommentEntity",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "UserProgressEntity",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    CourseId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProgressEntity", x => new { x.UserId, x.CourseId });
                    table.ForeignKey(
                        name: "FK_UserProgressEntity_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserProgressEntity_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProgressEntity_UserProgressUserId_UserProgressCourseId",
                table: "ProgressEntity",
                columns: new[] { "UserProgressUserId", "UserProgressCourseId" });

            migrationBuilder.CreateIndex(
                name: "IX_UserProgressEntity_CourseId",
                table: "UserProgressEntity",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_CommentEntity_AspNetUsers_AuthorId",
                table: "CommentEntity",
                column: "AuthorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CommentEntity_Lessons_LessonId",
                table: "CommentEntity",
                column: "LessonId",
                principalTable: "Lessons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CommentEntity_CommentEntity_RootCommentId",
                table: "CommentEntity",
                column: "RootCommentId",
                principalTable: "CommentEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProgressEntity_Lessons_LessonId",
                table: "ProgressEntity",
                column: "LessonId",
                principalTable: "Lessons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProgressEntity_UserProgressEntity_UserProgressUserId_UserPr~",
                table: "ProgressEntity",
                columns: new[] { "UserProgressUserId", "UserProgressCourseId" },
                principalTable: "UserProgressEntity",
                principalColumns: new[] { "UserId", "CourseId" },
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserCommentLikesEntity_CommentEntity_CommentId",
                table: "UserCommentLikesEntity",
                column: "CommentId",
                principalTable: "CommentEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserCourseEntity_Courses_CourseId",
                table: "UserCourseEntity",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserCourseEntity_AspNetUsers_SubscriberId",
                table: "UserCourseEntity",
                column: "SubscriberId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
