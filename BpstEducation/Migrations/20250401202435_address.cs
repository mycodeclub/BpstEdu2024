using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BpstEducation.Migrations
{
    /// <inheritdoc />
    public partial class address : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddressLine2",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "AddressLine3",
                table: "Address");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AddressLine2",
                table: "Address",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AddressLine3",
                table: "Address",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
