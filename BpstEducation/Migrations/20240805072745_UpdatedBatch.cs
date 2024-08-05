using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BpstEducation.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedBatch : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Batchs");

            migrationBuilder.RenameColumn(
                name: "LastUpdatedBy",
                table: "Batchs",
                newName: "CreatedDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "Batchs",
                newName: "LastUpdatedBy");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedBy",
                table: "Batchs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
