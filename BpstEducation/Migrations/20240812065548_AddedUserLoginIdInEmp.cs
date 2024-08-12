using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BpstEducation.Migrations
{
    /// <inheritdoc />
    public partial class AddedUserLoginIdInEmp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LoginIdGuid",
                table: "employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LoginIdGuid",
                table: "employees");
        }
    }
}
