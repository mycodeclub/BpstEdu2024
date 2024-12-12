using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BpstEducation.Migrations
{
    /// <inheritdoc />
    public partial class nwe : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Registration_Address_AddressUniqueId",
                table: "Registration");

            migrationBuilder.DropIndex(
                name: "IX_Registration_AddressUniqueId",
                table: "Registration");

            migrationBuilder.DropColumn(
                name: "AddressUniqueId",
                table: "Registration");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Registration",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Registration");

            migrationBuilder.AddColumn<int>(
                name: "AddressUniqueId",
                table: "Registration",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Registration_AddressUniqueId",
                table: "Registration",
                column: "AddressUniqueId");

            migrationBuilder.AddForeignKey(
                name: "FK_Registration_Address_AddressUniqueId",
                table: "Registration",
                column: "AddressUniqueId",
                principalTable: "Address",
                principalColumn: "UniqueId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
