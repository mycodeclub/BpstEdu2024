using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BpstEducation.Migrations
{
    /// <inheritdoc />
    public partial class student : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PaymentMethod",
                table: "Fees");

            migrationBuilder.DropColumn(
                name: "PaymentProofPath",
                table: "Fees");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PaymentMethod",
                table: "Fees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PaymentProofPath",
                table: "Fees",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
