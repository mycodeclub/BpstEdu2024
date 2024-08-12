using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BpstEducation.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedCourse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RegistrationForm_CourseCategories_ApplicationFor",
                table: "RegistrationForm");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentBatch_Batchs_BatchId",
                table: "StudentBatch");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentBatch_RegistrationForm_RegistrationId",
                table: "StudentBatch");

            migrationBuilder.DropForeignKey(
                name: "FK_students_Batchs_BatchId",
                table: "students");

            migrationBuilder.DropForeignKey(
                name: "FK_students_CourseCategories_CourseCategoryID",
                table: "students");

            migrationBuilder.DropTable(
                name: "CourseCategories");

            migrationBuilder.DropIndex(
                name: "IX_students_BatchId",
                table: "students");

            migrationBuilder.DropIndex(
                name: "IX_students_CourseCategoryID",
                table: "students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentBatch",
                table: "StudentBatch");

            migrationBuilder.DeleteData(
                table: "Qualification",
                keyColumn: "UniqueId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Qualification",
                keyColumn: "UniqueId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Qualification",
                keyColumn: "UniqueId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Qualification",
                keyColumn: "UniqueId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Qualification",
                keyColumn: "UniqueId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Qualification",
                keyColumn: "UniqueId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Qualification",
                keyColumn: "UniqueId",
                keyValue: 7);

            migrationBuilder.DropColumn(
                name: "BatchId",
                table: "students");

            migrationBuilder.DropColumn(
                name: "CourseCategoryID",
                table: "students");

            migrationBuilder.RenameTable(
                name: "StudentBatch",
                newName: "BatchStudents");

            migrationBuilder.RenameColumn(
                name: "CourseId",
                table: "students",
                newName: "CourseOfInterestId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentBatch_RegistrationId",
                table: "BatchStudents",
                newName: "IX_BatchStudents_RegistrationId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentBatch_BatchId",
                table: "BatchStudents",
                newName: "IX_BatchStudents_BatchId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BatchStudents",
                table: "BatchStudents",
                column: "UniqueId");

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    UniqueId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.UniqueId);
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "UniqueId", "Name" },
                values: new object[,]
                {
                    { 1, "Programming Classes (for Rising Stars - IX - XII )" },
                    { 2, "Software Engineering .Net Internship - 6 months " },
                    { 3, "Software Engineering .Net Internship  -  45 days " },
                    { 4, "Cyber Security" },
                    { 5, " Game Development" },
                    { 6, "Hardware / Networking" },
                    { 7, "Others" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_students_CourseOfInterestId",
                table: "students",
                column: "CourseOfInterestId");

            migrationBuilder.CreateIndex(
                name: "IX_Batchs_CourseId",
                table: "Batchs",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Batchs_Courses_CourseId",
                table: "Batchs",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "UniqueId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BatchStudents_Batchs_BatchId",
                table: "BatchStudents",
                column: "BatchId",
                principalTable: "Batchs",
                principalColumn: "UniqueId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BatchStudents_RegistrationForm_RegistrationId",
                table: "BatchStudents",
                column: "RegistrationId",
                principalTable: "RegistrationForm",
                principalColumn: "UniqueId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RegistrationForm_Courses_ApplicationFor",
                table: "RegistrationForm",
                column: "ApplicationFor",
                principalTable: "Courses",
                principalColumn: "UniqueId");

            migrationBuilder.AddForeignKey(
                name: "FK_students_Courses_CourseOfInterestId",
                table: "students",
                column: "CourseOfInterestId",
                principalTable: "Courses",
                principalColumn: "UniqueId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Batchs_Courses_CourseId",
                table: "Batchs");

            migrationBuilder.DropForeignKey(
                name: "FK_BatchStudents_Batchs_BatchId",
                table: "BatchStudents");

            migrationBuilder.DropForeignKey(
                name: "FK_BatchStudents_RegistrationForm_RegistrationId",
                table: "BatchStudents");

            migrationBuilder.DropForeignKey(
                name: "FK_RegistrationForm_Courses_ApplicationFor",
                table: "RegistrationForm");

            migrationBuilder.DropForeignKey(
                name: "FK_students_Courses_CourseOfInterestId",
                table: "students");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_students_CourseOfInterestId",
                table: "students");

            migrationBuilder.DropIndex(
                name: "IX_Batchs_CourseId",
                table: "Batchs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BatchStudents",
                table: "BatchStudents");

            migrationBuilder.RenameTable(
                name: "BatchStudents",
                newName: "StudentBatch");

            migrationBuilder.RenameColumn(
                name: "CourseOfInterestId",
                table: "students",
                newName: "CourseId");

            migrationBuilder.RenameIndex(
                name: "IX_BatchStudents_RegistrationId",
                table: "StudentBatch",
                newName: "IX_StudentBatch_RegistrationId");

            migrationBuilder.RenameIndex(
                name: "IX_BatchStudents_BatchId",
                table: "StudentBatch",
                newName: "IX_StudentBatch_BatchId");

            migrationBuilder.AddColumn<int>(
                name: "BatchId",
                table: "students",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CourseCategoryID",
                table: "students",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentBatch",
                table: "StudentBatch",
                column: "UniqueId");

            migrationBuilder.CreateTable(
                name: "CourseCategories",
                columns: table => new
                {
                    UniqueId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseCategories", x => x.UniqueId);
                });

            migrationBuilder.InsertData(
                table: "CourseCategories",
                columns: new[] { "UniqueId", "Name" },
                values: new object[,]
                {
                    { 2, "Programming Classes (for Rising Stars - IX - XII )" },
                    { 3, ".Net Internship " },
                    { 4, " Game Development" },
                    { 5, "Cyber Security" },
                    { 6, "Hardware/Networking" },
                    { 7, " Software Engineering Internship - 6 months " },
                    { 8, "Software Engineering Internship -  45 days " },
                    { 9, "others" }
                });

            migrationBuilder.InsertData(
                table: "Qualification",
                columns: new[] { "UniqueId", "Name" },
                values: new object[,]
                {
                    { 1, "Under Graduate " },
                    { 2, "Polytechnic / Diploma" },
                    { 3, "BCA" },
                    { 4, "B.Tech" },
                    { 5, "MCA" },
                    { 6, "Other" },
                    { 7, "N/A  " }
                });

            migrationBuilder.CreateIndex(
                name: "IX_students_BatchId",
                table: "students",
                column: "BatchId");

            migrationBuilder.CreateIndex(
                name: "IX_students_CourseCategoryID",
                table: "students",
                column: "CourseCategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_RegistrationForm_CourseCategories_ApplicationFor",
                table: "RegistrationForm",
                column: "ApplicationFor",
                principalTable: "CourseCategories",
                principalColumn: "UniqueId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentBatch_Batchs_BatchId",
                table: "StudentBatch",
                column: "BatchId",
                principalTable: "Batchs",
                principalColumn: "UniqueId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentBatch_RegistrationForm_RegistrationId",
                table: "StudentBatch",
                column: "RegistrationId",
                principalTable: "RegistrationForm",
                principalColumn: "UniqueId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_students_Batchs_BatchId",
                table: "students",
                column: "BatchId",
                principalTable: "Batchs",
                principalColumn: "UniqueId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_students_CourseCategories_CourseCategoryID",
                table: "students",
                column: "CourseCategoryID",
                principalTable: "CourseCategories",
                principalColumn: "UniqueId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
