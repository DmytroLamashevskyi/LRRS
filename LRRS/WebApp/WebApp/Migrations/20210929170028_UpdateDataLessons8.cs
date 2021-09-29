using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApp.Migrations
{
    public partial class UpdateDataLessons8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FileModel_Lesson_LessonId",
                schema: "Identity",
                table: "FileModel");

            migrationBuilder.DropForeignKey(
                name: "FK_Lesson_AspNetUsers_AuthorId",
                schema: "Identity",
                table: "Lesson");

            migrationBuilder.DropForeignKey(
                name: "FK_Lesson_Cource_CourceId",
                schema: "Identity",
                table: "Lesson");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Lesson",
                schema: "Identity",
                table: "Lesson");

            migrationBuilder.RenameTable(
                name: "Lesson",
                schema: "Identity",
                newName: "Lessons",
                newSchema: "Identity");

            migrationBuilder.RenameIndex(
                name: "IX_Lesson_CourceId",
                schema: "Identity",
                table: "Lessons",
                newName: "IX_Lessons_CourceId");

            migrationBuilder.RenameIndex(
                name: "IX_Lesson_AuthorId",
                schema: "Identity",
                table: "Lessons",
                newName: "IX_Lessons_AuthorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Lessons",
                schema: "Identity",
                table: "Lessons",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FileModel_Lessons_LessonId",
                schema: "Identity",
                table: "FileModel",
                column: "LessonId",
                principalSchema: "Identity",
                principalTable: "Lessons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Lessons_AspNetUsers_AuthorId",
                schema: "Identity",
                table: "Lessons",
                column: "AuthorId",
                principalSchema: "Identity",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Lessons_Cource_CourceId",
                schema: "Identity",
                table: "Lessons",
                column: "CourceId",
                principalSchema: "Identity",
                principalTable: "Cource",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FileModel_Lessons_LessonId",
                schema: "Identity",
                table: "FileModel");

            migrationBuilder.DropForeignKey(
                name: "FK_Lessons_AspNetUsers_AuthorId",
                schema: "Identity",
                table: "Lessons");

            migrationBuilder.DropForeignKey(
                name: "FK_Lessons_Cource_CourceId",
                schema: "Identity",
                table: "Lessons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Lessons",
                schema: "Identity",
                table: "Lessons");

            migrationBuilder.RenameTable(
                name: "Lessons",
                schema: "Identity",
                newName: "Lesson",
                newSchema: "Identity");

            migrationBuilder.RenameIndex(
                name: "IX_Lessons_CourceId",
                schema: "Identity",
                table: "Lesson",
                newName: "IX_Lesson_CourceId");

            migrationBuilder.RenameIndex(
                name: "IX_Lessons_AuthorId",
                schema: "Identity",
                table: "Lesson",
                newName: "IX_Lesson_AuthorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Lesson",
                schema: "Identity",
                table: "Lesson",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FileModel_Lesson_LessonId",
                schema: "Identity",
                table: "FileModel",
                column: "LessonId",
                principalSchema: "Identity",
                principalTable: "Lesson",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Lesson_AspNetUsers_AuthorId",
                schema: "Identity",
                table: "Lesson",
                column: "AuthorId",
                principalSchema: "Identity",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Lesson_Cource_CourceId",
                schema: "Identity",
                table: "Lesson",
                column: "CourceId",
                principalSchema: "Identity",
                principalTable: "Cource",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
