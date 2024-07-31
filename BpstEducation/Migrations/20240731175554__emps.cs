using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BpstEducation.Migrations
{
    /// <inheritdoc />
    public partial class _emps : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_employees_Address_AddressId",
                table: "employees");

            migrationBuilder.DropIndex(
                name: "IX_employees_AddressId",
                table: "employees");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "employees");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "employees");

            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "employees",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_employees_AddressId",
                table: "employees",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_employees_Address_AddressId",
                table: "employees",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "UniqueId");
        }
    }
}
