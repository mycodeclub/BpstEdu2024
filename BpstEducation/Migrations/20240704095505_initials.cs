using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BpstEducation.Migrations
{
    /// <inheritdoc />
    public partial class initials : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RegistrationForm_EducationBoardsMaster_BoardId",
                table: "RegistrationForm");

            migrationBuilder.DropIndex(
                name: "IX_RegistrationForm_BoardId",
                table: "RegistrationForm");

            migrationBuilder.DropColumn(
                name: "BoardId",
                table: "RegistrationForm");

            migrationBuilder.RenameColumn(
                name: "HighestQualification",
                table: "RegistrationForm",
                newName: "Qualification");

            migrationBuilder.RenameColumn(
                name: "CurrentlyPursuing",
                table: "RegistrationForm",
                newName: "Address");

            migrationBuilder.CreateTable(
                name: "Qualification",
                columns: table => new
                {
                    UniqueId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Qualification", x => x.UniqueId);
                });

            migrationBuilder.UpdateData(
                table: "CourseCategories",
                keyColumn: "UniqueId",
                keyValue: 6,
                column: "Name",
                value: "Hardware/Networking");

            migrationBuilder.InsertData(
                table: "CourseCategories",
                columns: new[] { "UniqueId", "Name" },
                values: new object[] { 7, " Others " });

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Qualification");

            migrationBuilder.DeleteData(
                table: "CourseCategories",
                keyColumn: "UniqueId",
                keyValue: 7);

            migrationBuilder.RenameColumn(
                name: "Qualification",
                table: "RegistrationForm",
                newName: "HighestQualification");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "RegistrationForm",
                newName: "CurrentlyPursuing");

            migrationBuilder.AddColumn<int>(
                name: "BoardId",
                table: "RegistrationForm",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "CourseCategories",
                keyColumn: "UniqueId",
                keyValue: 6,
                column: "Name",
                value: " Others ");

            migrationBuilder.CreateIndex(
                name: "IX_RegistrationForm_BoardId",
                table: "RegistrationForm",
                column: "BoardId");

            migrationBuilder.AddForeignKey(
                name: "FK_RegistrationForm_EducationBoardsMaster_BoardId",
                table: "RegistrationForm",
                column: "BoardId",
                principalTable: "EducationBoardsMaster",
                principalColumn: "UniqueId");
        }
    }
}
