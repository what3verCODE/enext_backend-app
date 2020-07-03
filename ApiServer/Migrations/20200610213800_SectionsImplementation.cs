using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiServer.Migrations
{
    public partial class SectionsImplementation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnswerEntity_QuestionEntity_QuestionId",
                table: "AnswerEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_QuestionEntity_Sections_SectionId",
                table: "QuestionEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QuestionEntity",
                table: "QuestionEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AnswerEntity",
                table: "AnswerEntity");

            migrationBuilder.RenameTable(
                name: "QuestionEntity",
                newName: "Questions");

            migrationBuilder.RenameTable(
                name: "AnswerEntity",
                newName: "Answers");

            migrationBuilder.RenameIndex(
                name: "IX_QuestionEntity_SectionId",
                table: "Questions",
                newName: "IX_Questions_SectionId");

            migrationBuilder.RenameIndex(
                name: "IX_AnswerEntity_QuestionId",
                table: "Answers",
                newName: "IX_Answers_QuestionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Questions",
                table: "Questions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Answers",
                table: "Answers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_Questions_QuestionId",
                table: "Answers",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Sections_SectionId",
                table: "Questions",
                column: "SectionId",
                principalTable: "Sections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_Questions_QuestionId",
                table: "Answers");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Sections_SectionId",
                table: "Questions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Questions",
                table: "Questions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Answers",
                table: "Answers");

            migrationBuilder.RenameTable(
                name: "Questions",
                newName: "QuestionEntity");

            migrationBuilder.RenameTable(
                name: "Answers",
                newName: "AnswerEntity");

            migrationBuilder.RenameIndex(
                name: "IX_Questions_SectionId",
                table: "QuestionEntity",
                newName: "IX_QuestionEntity_SectionId");

            migrationBuilder.RenameIndex(
                name: "IX_Answers_QuestionId",
                table: "AnswerEntity",
                newName: "IX_AnswerEntity_QuestionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuestionEntity",
                table: "QuestionEntity",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AnswerEntity",
                table: "AnswerEntity",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AnswerEntity_QuestionEntity_QuestionId",
                table: "AnswerEntity",
                column: "QuestionId",
                principalTable: "QuestionEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionEntity_Sections_SectionId",
                table: "QuestionEntity",
                column: "SectionId",
                principalTable: "Sections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
