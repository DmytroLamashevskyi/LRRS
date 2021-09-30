using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApp.Migrations
{
    public partial class UpdateDataLessons12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Data",
                schema: "Identity",
                table: "FileModel");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                schema: "Identity",
                table: "FileModel");

            migrationBuilder.DropColumn(
                name: "FilePath",
                schema: "Identity",
                table: "FileModel");

            migrationBuilder.CreateTable(
                name: "FileOnFileSystem",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileOnFileSystem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FileOnFileSystem_FileModel_Id",
                        column: x => x.Id,
                        principalSchema: "Identity",
                        principalTable: "FileModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Grades",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    LessonId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CourceId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Grades_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Grades_Cource_CourceId",
                        column: x => x.CourceId,
                        principalSchema: "Identity",
                        principalTable: "Cource",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Grades_Lessons_LessonId",
                        column: x => x.LessonId,
                        principalSchema: "Identity",
                        principalTable: "Lessons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FileOnDatabase",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Data = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    GradeId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileOnDatabase", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FileOnDatabase_FileModel_Id",
                        column: x => x.Id,
                        principalSchema: "Identity",
                        principalTable: "FileModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FileOnDatabase_Grades_GradeId",
                        column: x => x.GradeId,
                        principalSchema: "Identity",
                        principalTable: "Grades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FileOnDatabase_GradeId",
                schema: "Identity",
                table: "FileOnDatabase",
                column: "GradeId");

            migrationBuilder.CreateIndex(
                name: "IX_Grades_CourceId",
                schema: "Identity",
                table: "Grades",
                column: "CourceId");

            migrationBuilder.CreateIndex(
                name: "IX_Grades_LessonId",
                schema: "Identity",
                table: "Grades",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_Grades_UserId",
                schema: "Identity",
                table: "Grades",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FileOnDatabase",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "FileOnFileSystem",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "Grades",
                schema: "Identity");

            migrationBuilder.AddColumn<byte[]>(
                name: "Data",
                schema: "Identity",
                table: "FileModel",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                schema: "Identity",
                table: "FileModel",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FilePath",
                schema: "Identity",
                table: "FileModel",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
