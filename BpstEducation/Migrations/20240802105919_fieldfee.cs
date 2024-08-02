using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BpstEducation.Migrations
{
    /// <inheritdoc />
    public partial class fieldfee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RemainingFee",
                table: "Fees",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TotalFee",
                table: "Fees",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RemainingFee",
                table: "Fees");

            migrationBuilder.DropColumn(
                name: "TotalFee",
                table: "Fees");
        }
    }
}
