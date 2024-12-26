using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BpstEducation.Migrations
{
    /// <inheritdoc />
    public partial class ReEditedModule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Students");

            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "Batchs",
                newName: "StartDateTime");

            migrationBuilder.AddColumn<int>(
                name: "AddressUniqueId",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Students_AddressUniqueId",
                table: "Students",
                column: "AddressUniqueId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Address_AddressUniqueId",
                table: "Students",
                column: "AddressUniqueId",
                principalTable: "Address",
                principalColumn: "UniqueId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Address_AddressUniqueId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_AddressUniqueId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "AddressUniqueId",
                table: "Students");

            migrationBuilder.RenameColumn(
                name: "StartDateTime",
                table: "Batchs",
                newName: "StartDate");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
