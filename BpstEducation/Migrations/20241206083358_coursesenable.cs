using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BpstEducation.Migrations
{
    /// <inheritdoc />
    public partial class coursesenable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IntershipAvailable",
                table: "Courses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "UniqueId",
                keyValue: 1,
                column: "IntershipAvailable",
                value: false);

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "UniqueId",
                keyValue: 2,
                column: "IntershipAvailable",
                value: false);

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "UniqueId",
                keyValue: 3,
                column: "IntershipAvailable",
                value: false);

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "UniqueId",
                keyValue: 4,
                column: "IntershipAvailable",
                value: false);

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "UniqueId",
                keyValue: 5,
                column: "IntershipAvailable",
                value: false);

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "UniqueId",
                keyValue: 6,
                column: "IntershipAvailable",
                value: false);

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "UniqueId",
                keyValue: 7,
                column: "IntershipAvailable",
                value: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IntershipAvailable",
                table: "Courses");
        }
    }
}
