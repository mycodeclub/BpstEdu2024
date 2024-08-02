using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BpstEducation.Migrations
{
    /// <inheritdoc />
    public partial class studentfee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fees_RegistrationForm_StudentId",
                table: "Fees");

            migrationBuilder.DropColumn(
                name: "FeeInstallment",
                table: "Fees");

            migrationBuilder.RenameColumn(
                name: "Fees",
                table: "students",
                newName: "MyTrainingFee");

            migrationBuilder.AddColumn<int>(
                name: "MyDiscount",
                table: "students",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SubmittedFee",
                table: "Fees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Fees_students_StudentId",
                table: "Fees",
                column: "StudentId",
                principalTable: "students",
                principalColumn: "UniqueId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fees_students_StudentId",
                table: "Fees");

            migrationBuilder.DropColumn(
                name: "MyDiscount",
                table: "students");

            migrationBuilder.DropColumn(
                name: "SubmittedFee",
                table: "Fees");

            migrationBuilder.RenameColumn(
                name: "MyTrainingFee",
                table: "students",
                newName: "Fees");

            migrationBuilder.AddColumn<string>(
                name: "FeeInstallment",
                table: "Fees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Fees_RegistrationForm_StudentId",
                table: "Fees",
                column: "StudentId",
                principalTable: "RegistrationForm",
                principalColumn: "UniqueId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
