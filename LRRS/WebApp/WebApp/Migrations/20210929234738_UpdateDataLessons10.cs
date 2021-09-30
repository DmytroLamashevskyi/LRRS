using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApp.Migrations
{
    public partial class UpdateDataLessons10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentCource_AspNetUsers_StudentId",
                schema: "Identity",
                table: "StudentCource");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentCource_Cource_CourceId",
                schema: "Identity",
                table: "StudentCource");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentCource",
                schema: "Identity",
                table: "StudentCource");

            migrationBuilder.RenameTable(
                name: "StudentCource",
                schema: "Identity",
                newName: "Students",
                newSchema: "Identity");

            migrationBuilder.RenameIndex(
                name: "IX_StudentCource_StudentId",
                schema: "Identity",
                table: "Students",
                newName: "IX_Students_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentCource_CourceId",
                schema: "Identity",
                table: "Students",
                newName: "IX_Students_CourceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Students",
                schema: "Identity",
                table: "Students",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_AspNetUsers_StudentId",
                schema: "Identity",
                table: "Students",
                column: "StudentId",
                principalSchema: "Identity",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Cource_CourceId",
                schema: "Identity",
                table: "Students",
                column: "CourceId",
                principalSchema: "Identity",
                principalTable: "Cource",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_AspNetUsers_StudentId",
                schema: "Identity",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Cource_CourceId",
                schema: "Identity",
                table: "Students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Students",
                schema: "Identity",
                table: "Students");

            migrationBuilder.RenameTable(
                name: "Students",
                schema: "Identity",
                newName: "StudentCource",
                newSchema: "Identity");

            migrationBuilder.RenameIndex(
                name: "IX_Students_StudentId",
                schema: "Identity",
                table: "StudentCource",
                newName: "IX_StudentCource_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_Students_CourceId",
                schema: "Identity",
                table: "StudentCource",
                newName: "IX_StudentCource_CourceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentCource",
                schema: "Identity",
                table: "StudentCource",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCource_AspNetUsers_StudentId",
                schema: "Identity",
                table: "StudentCource",
                column: "StudentId",
                principalSchema: "Identity",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCource_Cource_CourceId",
                schema: "Identity",
                table: "StudentCource",
                column: "CourceId",
                principalSchema: "Identity",
                principalTable: "Cource",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
