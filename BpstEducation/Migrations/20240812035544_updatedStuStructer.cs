using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BpstEducation.Migrations
{
    /// <inheritdoc />
    public partial class updatedStuStructer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BatchStudents_RegistrationForm_RegistrationId",
                table: "BatchStudents");

            migrationBuilder.AlterColumn<int>(
                name: "RegistrationId",
                table: "BatchStudents",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "BatchStudents",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_BatchStudents_students_RegistrationId",
                table: "BatchStudents",
                column: "RegistrationId",
                principalTable: "students",
                principalColumn: "UniqueId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BatchStudents_students_RegistrationId",
                table: "BatchStudents");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "BatchStudents");

            migrationBuilder.AlterColumn<int>(
                name: "RegistrationId",
                table: "BatchStudents",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BatchStudents_RegistrationForm_RegistrationId",
                table: "BatchStudents",
                column: "RegistrationId",
                principalTable: "RegistrationForm",
                principalColumn: "UniqueId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
