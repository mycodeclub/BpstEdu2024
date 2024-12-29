using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BpstEducation.Migrations
{
    /// <inheritdoc />
    public partial class addedFee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ApplicationId",
                table: "Students",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Message",
                table: "Applications",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "ErrorLogDuringStudentGenration",
                table: "Applications",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "UniqueId",
                keyValue: 1,
                column: "ErrorLogDuringStudentGenration",
                value: "");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "UniqueId",
                keyValue: 2,
                column: "ErrorLogDuringStudentGenration",
                value: "");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "UniqueId",
                keyValue: 3,
                column: "ErrorLogDuringStudentGenration",
                value: "");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "UniqueId",
                keyValue: 4,
                column: "ErrorLogDuringStudentGenration",
                value: "");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "UniqueId",
                keyValue: 5,
                column: "ErrorLogDuringStudentGenration",
                value: "");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "UniqueId",
                keyValue: 6,
                column: "ErrorLogDuringStudentGenration",
                value: "");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "UniqueId",
                keyValue: 7,
                column: "ErrorLogDuringStudentGenration",
                value: "");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "UniqueId",
                keyValue: 8,
                column: "ErrorLogDuringStudentGenration",
                value: "");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "UniqueId",
                keyValue: 9,
                column: "ErrorLogDuringStudentGenration",
                value: "");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "UniqueId",
                keyValue: 10,
                column: "ErrorLogDuringStudentGenration",
                value: "");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "UniqueId",
                keyValue: 11,
                column: "ErrorLogDuringStudentGenration",
                value: "");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "UniqueId",
                keyValue: 12,
                column: "ErrorLogDuringStudentGenration",
                value: "");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "UniqueId",
                keyValue: 13,
                column: "ErrorLogDuringStudentGenration",
                value: "");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "UniqueId",
                keyValue: 14,
                column: "ErrorLogDuringStudentGenration",
                value: "");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "UniqueId",
                keyValue: 15,
                column: "ErrorLogDuringStudentGenration",
                value: "");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "UniqueId",
                keyValue: 16,
                column: "ErrorLogDuringStudentGenration",
                value: "");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "UniqueId",
                keyValue: 17,
                column: "ErrorLogDuringStudentGenration",
                value: "");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "UniqueId",
                keyValue: 18,
                column: "ErrorLogDuringStudentGenration",
                value: "");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "UniqueId",
                keyValue: 19,
                column: "ErrorLogDuringStudentGenration",
                value: "");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "UniqueId",
                keyValue: 20,
                column: "ErrorLogDuringStudentGenration",
                value: "");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "UniqueId",
                keyValue: 21,
                column: "ErrorLogDuringStudentGenration",
                value: "");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "UniqueId",
                keyValue: 22,
                column: "ErrorLogDuringStudentGenration",
                value: "");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "UniqueId",
                keyValue: 23,
                column: "ErrorLogDuringStudentGenration",
                value: "");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "UniqueId",
                keyValue: 24,
                column: "ErrorLogDuringStudentGenration",
                value: "");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "UniqueId",
                keyValue: 25,
                column: "ErrorLogDuringStudentGenration",
                value: "");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "UniqueId",
                keyValue: 26,
                column: "ErrorLogDuringStudentGenration",
                value: "");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "UniqueId",
                keyValue: 27,
                column: "ErrorLogDuringStudentGenration",
                value: "");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "UniqueId",
                keyValue: 28,
                column: "ErrorLogDuringStudentGenration",
                value: "");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "UniqueId",
                keyValue: 29,
                column: "ErrorLogDuringStudentGenration",
                value: "");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "UniqueId",
                keyValue: 30,
                column: "ErrorLogDuringStudentGenration",
                value: "");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "UniqueId",
                keyValue: 31,
                column: "ErrorLogDuringStudentGenration",
                value: "");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "UniqueId",
                keyValue: 32,
                column: "ErrorLogDuringStudentGenration",
                value: "");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "UniqueId",
                keyValue: 33,
                column: "ErrorLogDuringStudentGenration",
                value: "");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "UniqueId",
                keyValue: 34,
                column: "ErrorLogDuringStudentGenration",
                value: "");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "UniqueId",
                keyValue: 35,
                column: "ErrorLogDuringStudentGenration",
                value: "");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "UniqueId",
                keyValue: 36,
                column: "ErrorLogDuringStudentGenration",
                value: "");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "UniqueId",
                keyValue: 37,
                column: "ErrorLogDuringStudentGenration",
                value: "");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "UniqueId",
                keyValue: 38,
                column: "ErrorLogDuringStudentGenration",
                value: "");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "UniqueId",
                keyValue: 39,
                column: "ErrorLogDuringStudentGenration",
                value: "");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "UniqueId",
                keyValue: 40,
                column: "ErrorLogDuringStudentGenration",
                value: "");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "UniqueId",
                keyValue: 41,
                column: "ErrorLogDuringStudentGenration",
                value: "");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "UniqueId",
                keyValue: 42,
                column: "ErrorLogDuringStudentGenration",
                value: "");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "UniqueId",
                keyValue: 43,
                column: "ErrorLogDuringStudentGenration",
                value: "");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "UniqueId",
                keyValue: 44,
                column: "ErrorLogDuringStudentGenration",
                value: "");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "UniqueId",
                keyValue: 45,
                column: "ErrorLogDuringStudentGenration",
                value: "");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "UniqueId",
                keyValue: 46,
                column: "ErrorLogDuringStudentGenration",
                value: "");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "UniqueId",
                keyValue: 47,
                column: "ErrorLogDuringStudentGenration",
                value: "");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "UniqueId",
                keyValue: 48,
                column: "ErrorLogDuringStudentGenration",
                value: "");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "UniqueId",
                keyValue: 49,
                column: "ErrorLogDuringStudentGenration",
                value: "");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "UniqueId",
                keyValue: 50,
                column: "ErrorLogDuringStudentGenration",
                value: "");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "UniqueId",
                keyValue: 51,
                column: "ErrorLogDuringStudentGenration",
                value: "");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "UniqueId",
                keyValue: 52,
                column: "ErrorLogDuringStudentGenration",
                value: "");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "UniqueId",
                keyValue: 53,
                column: "ErrorLogDuringStudentGenration",
                value: "");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "UniqueId",
                keyValue: 54,
                column: "ErrorLogDuringStudentGenration",
                value: "");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "UniqueId",
                keyValue: 55,
                column: "ErrorLogDuringStudentGenration",
                value: "");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "UniqueId",
                keyValue: 56,
                column: "ErrorLogDuringStudentGenration",
                value: "");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "UniqueId",
                keyValue: 57,
                column: "ErrorLogDuringStudentGenration",
                value: "");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "UniqueId",
                keyValue: 58,
                column: "ErrorLogDuringStudentGenration",
                value: "");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "UniqueId",
                keyValue: 59,
                column: "ErrorLogDuringStudentGenration",
                value: "");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "UniqueId",
                keyValue: 60,
                column: "ErrorLogDuringStudentGenration",
                value: "");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "UniqueId",
                keyValue: 61,
                column: "ErrorLogDuringStudentGenration",
                value: "");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "UniqueId",
                keyValue: 62,
                column: "ErrorLogDuringStudentGenration",
                value: "");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "UniqueId",
                keyValue: 63,
                column: "ErrorLogDuringStudentGenration",
                value: "");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "UniqueId",
                keyValue: 64,
                column: "ErrorLogDuringStudentGenration",
                value: "");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "UniqueId",
                keyValue: 65,
                column: "ErrorLogDuringStudentGenration",
                value: "");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "UniqueId",
                keyValue: 66,
                column: "ErrorLogDuringStudentGenration",
                value: "");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "UniqueId",
                keyValue: 67,
                column: "ErrorLogDuringStudentGenration",
                value: "");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "UniqueId",
                keyValue: 68,
                column: "ErrorLogDuringStudentGenration",
                value: "");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "UniqueId",
                keyValue: 69,
                column: "ErrorLogDuringStudentGenration",
                value: "");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "UniqueId",
                keyValue: 70,
                column: "ErrorLogDuringStudentGenration",
                value: "");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "UniqueId",
                keyValue: 71,
                column: "ErrorLogDuringStudentGenration",
                value: "");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "UniqueId",
                keyValue: 72,
                column: "ErrorLogDuringStudentGenration",
                value: "");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "UniqueId",
                keyValue: 73,
                column: "ErrorLogDuringStudentGenration",
                value: "");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "UniqueId",
                keyValue: 74,
                column: "ErrorLogDuringStudentGenration",
                value: "");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "UniqueId",
                keyValue: 75,
                column: "ErrorLogDuringStudentGenration",
                value: "");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "UniqueId",
                keyValue: 76,
                column: "ErrorLogDuringStudentGenration",
                value: "");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "UniqueId",
                keyValue: 77,
                column: "ErrorLogDuringStudentGenration",
                value: "");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "UniqueId",
                keyValue: 78,
                column: "ErrorLogDuringStudentGenration",
                value: "");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "UniqueId",
                keyValue: 79,
                column: "ErrorLogDuringStudentGenration",
                value: "");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "UniqueId",
                keyValue: 80,
                column: "ErrorLogDuringStudentGenration",
                value: "");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "UniqueId",
                keyValue: 81,
                column: "ErrorLogDuringStudentGenration",
                value: "");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "UniqueId",
                keyValue: 82,
                column: "ErrorLogDuringStudentGenration",
                value: "");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "UniqueId",
                keyValue: 83,
                column: "ErrorLogDuringStudentGenration",
                value: "");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "UniqueId",
                keyValue: 84,
                column: "ErrorLogDuringStudentGenration",
                value: "");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "UniqueId",
                keyValue: 85,
                column: "ErrorLogDuringStudentGenration",
                value: "");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "UniqueId",
                keyValue: 86,
                column: "ErrorLogDuringStudentGenration",
                value: "");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "UniqueId",
                keyValue: 87,
                column: "ErrorLogDuringStudentGenration",
                value: "");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "UniqueId",
                keyValue: 88,
                column: "ErrorLogDuringStudentGenration",
                value: "");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "UniqueId",
                keyValue: 89,
                column: "ErrorLogDuringStudentGenration",
                value: "");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "UniqueId",
                keyValue: 90,
                column: "ErrorLogDuringStudentGenration",
                value: "");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "UniqueId",
                keyValue: 91,
                column: "ErrorLogDuringStudentGenration",
                value: "");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "UniqueId",
                keyValue: 92,
                column: "ErrorLogDuringStudentGenration",
                value: "");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "UniqueId",
                keyValue: 93,
                column: "ErrorLogDuringStudentGenration",
                value: "");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "UniqueId",
                keyValue: 94,
                column: "ErrorLogDuringStudentGenration",
                value: "");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "UniqueId",
                keyValue: 95,
                column: "ErrorLogDuringStudentGenration",
                value: "");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "UniqueId",
                keyValue: 96,
                column: "ErrorLogDuringStudentGenration",
                value: "");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "UniqueId",
                keyValue: 97,
                column: "ErrorLogDuringStudentGenration",
                value: "");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "UniqueId",
                keyValue: 98,
                column: "ErrorLogDuringStudentGenration",
                value: "");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "UniqueId",
                keyValue: 99,
                column: "ErrorLogDuringStudentGenration",
                value: "");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "UniqueId",
                keyValue: 100,
                column: "ErrorLogDuringStudentGenration",
                value: "");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "UniqueId",
                keyValue: 101,
                column: "ErrorLogDuringStudentGenration",
                value: "");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "UniqueId",
                keyValue: 102,
                column: "ErrorLogDuringStudentGenration",
                value: "");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "UniqueId",
                keyValue: 103,
                column: "ErrorLogDuringStudentGenration",
                value: "");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "UniqueId",
                keyValue: 104,
                column: "ErrorLogDuringStudentGenration",
                value: "");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "UniqueId",
                keyValue: 105,
                column: "ErrorLogDuringStudentGenration",
                value: "");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "UniqueId",
                keyValue: 106,
                column: "ErrorLogDuringStudentGenration",
                value: "");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "UniqueId",
                keyValue: 107,
                column: "ErrorLogDuringStudentGenration",
                value: "");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "UniqueId",
                keyValue: 108,
                column: "ErrorLogDuringStudentGenration",
                value: "");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "UniqueId",
                keyValue: 109,
                column: "ErrorLogDuringStudentGenration",
                value: "");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "UniqueId",
                keyValue: 110,
                column: "ErrorLogDuringStudentGenration",
                value: "");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "UniqueId",
                keyValue: 111,
                column: "ErrorLogDuringStudentGenration",
                value: "");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "UniqueId",
                keyValue: 112,
                column: "ErrorLogDuringStudentGenration",
                value: "");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "UniqueId",
                keyValue: 113,
                column: "ErrorLogDuringStudentGenration",
                value: "");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "UniqueId",
                keyValue: 114,
                column: "ErrorLogDuringStudentGenration",
                value: "");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "UniqueId",
                keyValue: 115,
                column: "ErrorLogDuringStudentGenration",
                value: "");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "UniqueId",
                keyValue: 116,
                column: "ErrorLogDuringStudentGenration",
                value: "");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "UniqueId",
                keyValue: 117,
                column: "ErrorLogDuringStudentGenration",
                value: "");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "UniqueId",
                keyValue: 118,
                column: "ErrorLogDuringStudentGenration",
                value: "");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "UniqueId",
                keyValue: 119,
                column: "ErrorLogDuringStudentGenration",
                value: "");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "UniqueId",
                keyValue: 120,
                column: "ErrorLogDuringStudentGenration",
                value: "");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "UniqueId",
                keyValue: 121,
                column: "ErrorLogDuringStudentGenration",
                value: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApplicationId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "ErrorLogDuringStudentGenration",
                table: "Applications");

            migrationBuilder.AlterColumn<string>(
                name: "Message",
                table: "Applications",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
