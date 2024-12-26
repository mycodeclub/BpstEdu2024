using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BpstEducation.Migrations
{
    /// <inheritdoc />
    public partial class ReEditedModule2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ApplicationStatus",
                keyColumn: "UniqueId",
                keyValue: 1,
                column: "RegistrationStatus",
                value: "New Application");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ApplicationStatus",
                keyColumn: "UniqueId",
                keyValue: 1,
                column: "RegistrationStatus",
                value: "Applied");
        }
    }
}
