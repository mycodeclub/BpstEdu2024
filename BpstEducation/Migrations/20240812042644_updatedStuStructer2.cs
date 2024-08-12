using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BpstEducation.Migrations
{
    /// <inheritdoc />
    public partial class updatedStuStructer2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BatchStudents_students_RegistrationId",
                table: "BatchStudents");

            migrationBuilder.DropForeignKey(
                name: "FK_Fees_students_StudentId",
                table: "Fees");

            migrationBuilder.DropForeignKey(
                name: "FK_students_Courses_CourseOfInterestId",
                table: "students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_students",
                table: "students");

            migrationBuilder.DropIndex(
                name: "IX_BatchStudents_RegistrationId",
                table: "BatchStudents");

            migrationBuilder.DropColumn(
                name: "RegistrationId",
                table: "BatchStudents");

            migrationBuilder.RenameTable(
                name: "students",
                newName: "Students");

            migrationBuilder.RenameIndex(
                name: "IX_students_CourseOfInterestId",
                table: "Students",
                newName: "IX_Students_CourseOfInterestId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Students",
                table: "Students",
                column: "UniqueId");

            migrationBuilder.CreateIndex(
                name: "IX_BatchStudents_StudentId",
                table: "BatchStudents",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_BatchStudents_Students_StudentId",
                table: "BatchStudents",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "UniqueId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Fees_Students_StudentId",
                table: "Fees",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "UniqueId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Courses_CourseOfInterestId",
                table: "Students",
                column: "CourseOfInterestId",
                principalTable: "Courses",
                principalColumn: "UniqueId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BatchStudents_Students_StudentId",
                table: "BatchStudents");

            migrationBuilder.DropForeignKey(
                name: "FK_Fees_Students_StudentId",
                table: "Fees");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Courses_CourseOfInterestId",
                table: "Students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Students",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_BatchStudents_StudentId",
                table: "BatchStudents");

            migrationBuilder.RenameTable(
                name: "Students",
                newName: "students");

            migrationBuilder.RenameIndex(
                name: "IX_Students_CourseOfInterestId",
                table: "students",
                newName: "IX_students_CourseOfInterestId");

            migrationBuilder.AddColumn<int>(
                name: "RegistrationId",
                table: "BatchStudents",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_students",
                table: "students",
                column: "UniqueId");

            migrationBuilder.CreateIndex(
                name: "IX_BatchStudents_RegistrationId",
                table: "BatchStudents",
                column: "RegistrationId");

            migrationBuilder.AddForeignKey(
                name: "FK_BatchStudents_students_RegistrationId",
                table: "BatchStudents",
                column: "RegistrationId",
                principalTable: "students",
                principalColumn: "UniqueId");

            migrationBuilder.AddForeignKey(
                name: "FK_Fees_students_StudentId",
                table: "Fees",
                column: "StudentId",
                principalTable: "students",
                principalColumn: "UniqueId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_students_Courses_CourseOfInterestId",
                table: "students",
                column: "CourseOfInterestId",
                principalTable: "Courses",
                principalColumn: "UniqueId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
