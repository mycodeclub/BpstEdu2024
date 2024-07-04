using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BpstEducation.Migrations
{
    /// <inheritdoc />
    public partial class cources : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RegistrationForm_Course_ApplicationFor",
                table: "RegistrationForm");

            migrationBuilder.AddForeignKey(
                name: "FK_RegistrationForm_CourseCategories_ApplicationFor",
                table: "RegistrationForm",
                column: "ApplicationFor",
                principalTable: "CourseCategories",
                principalColumn: "UniqueId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RegistrationForm_CourseCategories_ApplicationFor",
                table: "RegistrationForm");

            migrationBuilder.AddForeignKey(
                name: "FK_RegistrationForm_Course_ApplicationFor",
                table: "RegistrationForm",
                column: "ApplicationFor",
                principalTable: "Course",
                principalColumn: "UniqueId");
        }
    }
}
