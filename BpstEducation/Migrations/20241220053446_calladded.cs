using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BpstEducation.Migrations
{
    /// <inheritdoc />
    public partial class calladded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Batchs",
                keyColumn: "UniqueId",
                keyValue: 2,
                column: "Title",
                value: "DotNet Industrial Training 6 Months - Morning");

            migrationBuilder.UpdateData(
                table: "Batchs",
                keyColumn: "UniqueId",
                keyValue: 3,
                column: "Title",
                value: "DotNet Internship ");

            migrationBuilder.UpdateData(
                table: "Batchs",
                keyColumn: "UniqueId",
                keyValue: 4,
                column: "Title",
                value: "Other Crash Course - Per Month");

            migrationBuilder.UpdateData(
                table: "Batchs",
                keyColumn: "UniqueId",
                keyValue: 5,
                column: "Title",
                value: "DotNet Industrial Training 6 Months - Evening");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Batchs",
                keyColumn: "UniqueId",
                keyValue: 2,
                column: "Title",
                value: "Rising Stars");

            migrationBuilder.UpdateData(
                table: "Batchs",
                keyColumn: "UniqueId",
                keyValue: 3,
                column: "Title",
                value: "Rising Stars");

            migrationBuilder.UpdateData(
                table: "Batchs",
                keyColumn: "UniqueId",
                keyValue: 4,
                column: "Title",
                value: "Rising Stars");

            migrationBuilder.UpdateData(
                table: "Batchs",
                keyColumn: "UniqueId",
                keyValue: 5,
                column: "Title",
                value: "Rising Stars");
        }
    }
}
