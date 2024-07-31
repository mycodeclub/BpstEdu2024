using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BpstEducation.Migrations
{
    /// <inheritdoc />
    public partial class _emp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Trainer",
                table: "Batchs");

            migrationBuilder.AddColumn<int>(
                name: "TrainerId",
                table: "Batchs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "employees",
                columns: table => new
                {
                    UniqueId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JobRole = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Experience = table.Column<int>(type: "int", nullable: true),
                    AddressId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employees", x => x.UniqueId);
                    table.ForeignKey(
                        name: "FK_employees_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "UniqueId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Batchs_TrainerId",
                table: "Batchs",
                column: "TrainerId");

            migrationBuilder.CreateIndex(
                name: "IX_employees_AddressId",
                table: "employees",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Batchs_employees_TrainerId",
                table: "Batchs",
                column: "TrainerId",
                principalTable: "employees",
                principalColumn: "UniqueId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Batchs_employees_TrainerId",
                table: "Batchs");

            migrationBuilder.DropTable(
                name: "employees");

            migrationBuilder.DropIndex(
                name: "IX_Batchs_TrainerId",
                table: "Batchs");

            migrationBuilder.DropColumn(
                name: "TrainerId",
                table: "Batchs");

            migrationBuilder.AddColumn<string>(
                name: "Trainer",
                table: "Batchs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
