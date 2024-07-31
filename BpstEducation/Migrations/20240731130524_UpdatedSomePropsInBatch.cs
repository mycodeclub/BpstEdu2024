using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BpstEducation.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedSomePropsInBatch : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BatchId",
                table: "Batchs");

            migrationBuilder.AddColumn<string>(
                name: "Duration",
                table: "Batchs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Duration",
                table: "Batchs");

            migrationBuilder.AddColumn<int>(
                name: "BatchId",
                table: "Batchs",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
