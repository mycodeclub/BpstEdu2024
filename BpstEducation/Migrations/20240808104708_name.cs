
using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BpstEducation.Migrations
{
    /// <inheritdoc />
    public partial class name : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "AppUser",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_students_BatchId",
                table: "students",
                column: "BatchId");

            migrationBuilder.AddForeignKey(
                name: "FK_students_Batchs_BatchId",
                table: "students",
                column: "BatchId",
                principalTable: "Batchs",
                principalColumn: "UniqueId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_students_Batchs_BatchId",
                table: "students");

            migrationBuilder.DropIndex(
                name: "IX_students_BatchId",
                table: "students");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "AppUser");

            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    UniqueId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseCategoryID = table.Column<int>(type: "int", nullable: false),
                    CourseDuration = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CourseFees = table.Column<int>(type: "int", nullable: false),
                    CourseName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    feeDiscount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.UniqueId);
                    table.ForeignKey(
                        name: "FK_Course_CourseCategories_CourseCategoryID",
                        column: x => x.CourseCategoryID,
                        principalTable: "CourseCategories",
                        principalColumn: "UniqueId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Course_CourseCategoryID",
                table: "Course",
                column: "CourseCategoryID");
        }
    }
}
