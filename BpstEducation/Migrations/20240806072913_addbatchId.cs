using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BpstEducation.Migrations
{
    /// <inheritdoc />
    public partial class addbatchId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RemainingFee",
                table: "Fees");

            migrationBuilder.DropColumn(
                name: "TotalFee",
                table: "Fees");

            migrationBuilder.AddColumn<int>(
                name: "BatchId",
                table: "Fees",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BatchId",
                table: "Fees");

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
    }
}
