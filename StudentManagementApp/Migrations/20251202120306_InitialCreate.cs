using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StudentManagementApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Height = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Weight = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentID);
                });

            migrationBuilder.CreateTable(
                name: "Grades",
                columns: table => new
                {
                    GradeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GradeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Section = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grades", x => x.GradeId);
                    table.ForeignKey(
                        name: "FK_Grades_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentID", "DateOfBirth", "Height", "StudentName", "Weight" },
                values: new object[,]
                {
                    { 1, new DateTime(2006, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1.76m, "Alex Johnson", 68.5f },
                    { 2, new DateTime(2007, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 1.65m, "Emily Carter", 54.3f },
                    { 3, new DateTime(2006, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 1.80m, "Liam Miller", 74.2f },
                    { 4, new DateTime(2007, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1.70m, "Sophia Brown", 59.8f }
                });

            migrationBuilder.InsertData(
                table: "Grades",
                columns: new[] { "GradeId", "GradeName", "Section", "StudentId" },
                values: new object[,]
                {
                    { 1, "A", "Mathematics", 1 },
                    { 2, "B", "Physics", 1 },
                    { 3, "A", "Computer Science", 1 },
                    { 4, "B", "Mathematics", 2 },
                    { 5, "A", "English Language", 2 },
                    { 6, "C", "Biology", 2 },
                    { 7, "A", "Mathematics", 3 },
                    { 8, "B", "Chemistry", 3 },
                    { 9, "A", "Physics", 3 },
                    { 10, "B", "History", 4 },
                    { 11, "A", "English Language", 4 },
                    { 12, "B", "Physical Education", 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Grades_StudentId",
                table: "Grades",
                column: "StudentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Grades");

            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
