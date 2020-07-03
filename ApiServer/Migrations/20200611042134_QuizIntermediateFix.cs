using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiServer.Migrations
{
    public partial class QuizIntermediateFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_QuizEntity_QuizId",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_QuizEntity_Sections_SectionId",
                table: "QuizEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QuizEntity",
                table: "QuizEntity");

            migrationBuilder.RenameTable(
                name: "QuizEntity",
                newName: "Quizzes");

            migrationBuilder.RenameIndex(
                name: "IX_QuizEntity_SectionId",
                table: "Quizzes",
                newName: "IX_Quizzes_SectionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Quizzes",
                table: "Quizzes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Quizzes_QuizId",
                table: "Questions",
                column: "QuizId",
                principalTable: "Quizzes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Quizzes_Sections_SectionId",
                table: "Quizzes",
                column: "SectionId",
                principalTable: "Sections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Quizzes_QuizId",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_Quizzes_Sections_SectionId",
                table: "Quizzes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Quizzes",
                table: "Quizzes");

            migrationBuilder.RenameTable(
                name: "Quizzes",
                newName: "QuizEntity");

            migrationBuilder.RenameIndex(
                name: "IX_Quizzes_SectionId",
                table: "QuizEntity",
                newName: "IX_QuizEntity_SectionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuizEntity",
                table: "QuizEntity",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_QuizEntity_QuizId",
                table: "Questions",
                column: "QuizId",
                principalTable: "QuizEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_QuizEntity_Sections_SectionId",
                table: "QuizEntity",
                column: "SectionId",
                principalTable: "Sections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
