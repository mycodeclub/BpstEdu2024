using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BpstEducation.Migrations
{
    /// <inheritdoc />
    public partial class updateseedata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fees_BatchStudents_BatchStudentUniqueId",
                table: "Fees");

            migrationBuilder.DropForeignKey(
                name: "FK_Fees_Batchs_BatchStudentId",
                table: "Fees");

            migrationBuilder.DropIndex(
                name: "IX_Fees_BatchStudentUniqueId",
                table: "Fees");

            migrationBuilder.DropColumn(
                name: "BatchStudentUniqueId",
                table: "Fees");

            migrationBuilder.UpdateData(
                table: "Batchs",
                keyColumn: "UniqueId",
                keyValue: 1,
                columns: new[] { "CourseId", "CreatedDate", "StartDateTime", "Title" },
                values: new object[] { 1, new DateTime(2025, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), "Rising Stars Programming" });

            migrationBuilder.UpdateData(
                table: "Batchs",
                keyColumn: "UniqueId",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Duration", "Title" },
                values: new object[] { new DateTime(2025, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "180 Days", "Full Stack Dev Internship 6 Months - Morning" });

            migrationBuilder.UpdateData(
                table: "Batchs",
                keyColumn: "UniqueId",
                keyValue: 3,
                columns: new[] { "CourseId", "CreatedDate", "Duration", "Title" },
                values: new object[] { 3, new DateTime(2025, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "45 Days", "Full Stack Dev Industrial Training 45 Days - Evening" });

            migrationBuilder.UpdateData(
                table: "Batchs",
                keyColumn: "UniqueId",
                keyValue: 4,
                columns: new[] { "BatchFee", "CourseId", "CreatedDate", "Duration", "StartDateTime", "Title" },
                values: new object[] { 10000, 4, new DateTime(2025, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "45 Days", new DateTime(2025, 1, 24, 9, 0, 0, 0, DateTimeKind.Unspecified), "Cyber Security 45 Days" });

            migrationBuilder.UpdateData(
                table: "Batchs",
                keyColumn: "UniqueId",
                keyValue: 5,
                columns: new[] { "BatchFee", "CourseId", "CreatedDate", "Duration", "StartDateTime", "Title" },
                values: new object[] { 12000, 5, new DateTime(2025, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "45 Days", new DateTime(2025, 4, 4, 9, 0, 0, 0, DateTimeKind.Unspecified), "Game Development 45 Days" });

            migrationBuilder.InsertData(
                table: "Batchs",
                columns: new[] { "UniqueId", "AssisTrainer", "BatchFee", "CourseId", "CreatedDate", "Description", "Duration", "LastUpdatedDate", "StartDateTime", "Title", "TrainerId" },
                values: new object[,]
                {
                    { 6, "", 12000, 6, new DateTime(2025, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "45 Days", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), "App Development 45 Days", 4 },
                    { 7, "", 8000, 7, new DateTime(2025, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "45 Days", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), "Networking Class 45 Days", 2 }
                });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "UniqueId",
                keyValue: 2,
                column: "Name",
                value: "Full Stack Development - Internship 6 months ");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "UniqueId",
                keyValue: 3,
                column: "Name",
                value: "Full Stack Development - Industrial Training  45 days ");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "UniqueId",
                keyValue: 4,
                column: "Name",
                value: "Cyber Security - 45 Days");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "UniqueId",
                keyValue: 5,
                column: "Name",
                value: "Game Development - 45 Days");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "UniqueId",
                keyValue: 6,
                column: "Name",
                value: "App Development - 45 Days");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "UniqueId",
                keyValue: 7,
                column: "Name",
                value: "Networking Class - 45 Days");

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "UniqueId", "IntershipAvailable", "Name" },
                values: new object[] { 8, true, "Others" });

            migrationBuilder.InsertData(
                table: "Batchs",
                columns: new[] { "UniqueId", "AssisTrainer", "BatchFee", "CourseId", "CreatedDate", "Description", "Duration", "LastUpdatedDate", "StartDateTime", "Title", "TrainerId" },
                values: new object[] { 8, "", 5000, 8, new DateTime(2025, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "", " 30 Days", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), "Other Courses", 3 });

            migrationBuilder.AddForeignKey(
                name: "FK_Fees_BatchStudents_BatchStudentId",
                table: "Fees",
                column: "BatchStudentId",
                principalTable: "BatchStudents",
                principalColumn: "UniqueId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fees_BatchStudents_BatchStudentId",
                table: "Fees");

            migrationBuilder.DeleteData(
                table: "Batchs",
                keyColumn: "UniqueId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Batchs",
                keyColumn: "UniqueId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Batchs",
                keyColumn: "UniqueId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "UniqueId",
                keyValue: 8);

            migrationBuilder.AddColumn<int>(
                name: "BatchStudentUniqueId",
                table: "Fees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Batchs",
                keyColumn: "UniqueId",
                keyValue: 1,
                columns: new[] { "CourseId", "CreatedDate", "StartDateTime", "Title" },
                values: new object[] { 3, new DateTime(2024, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "DotNet Internship " });

            migrationBuilder.UpdateData(
                table: "Batchs",
                keyColumn: "UniqueId",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Duration", "Title" },
                values: new object[] { new DateTime(2024, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "6 - Months", "DotNet Industrial Training 6 Months - Morning" });

            migrationBuilder.UpdateData(
                table: "Batchs",
                keyColumn: "UniqueId",
                keyValue: 3,
                columns: new[] { "CourseId", "CreatedDate", "Duration", "Title" },
                values: new object[] { 2, new DateTime(2024, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "6 - Months", "DotNet Industrial Training 6 Months - Evening" });

            migrationBuilder.UpdateData(
                table: "Batchs",
                keyColumn: "UniqueId",
                keyValue: 4,
                columns: new[] { "BatchFee", "CourseId", "CreatedDate", "Duration", "StartDateTime", "Title" },
                values: new object[] { 1000, 1, new DateTime(2024, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "1 Month", new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rising Stars" });

            migrationBuilder.UpdateData(
                table: "Batchs",
                keyColumn: "UniqueId",
                keyValue: 5,
                columns: new[] { "BatchFee", "CourseId", "CreatedDate", "Duration", "StartDateTime", "Title" },
                values: new object[] { 800, 7, new DateTime(2024, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "1 Month", new DateTime(2025, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Other Crash Course - Per Month" });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "UniqueId",
                keyValue: 2,
                column: "Name",
                value: "Software Engineering .Net Internship - 6 months ");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "UniqueId",
                keyValue: 3,
                column: "Name",
                value: "Software Engineering .Net Internship  -  45 days ");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "UniqueId",
                keyValue: 4,
                column: "Name",
                value: "Cyber Security");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "UniqueId",
                keyValue: 5,
                column: "Name",
                value: " Game Development");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "UniqueId",
                keyValue: 6,
                column: "Name",
                value: "Hardware / Networking");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "UniqueId",
                keyValue: 7,
                column: "Name",
                value: "Others");

            migrationBuilder.CreateIndex(
                name: "IX_Fees_BatchStudentUniqueId",
                table: "Fees",
                column: "BatchStudentUniqueId");

            migrationBuilder.AddForeignKey(
                name: "FK_Fees_BatchStudents_BatchStudentUniqueId",
                table: "Fees",
                column: "BatchStudentUniqueId",
                principalTable: "BatchStudents",
                principalColumn: "UniqueId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Fees_Batchs_BatchStudentId",
                table: "Fees",
                column: "BatchStudentId",
                principalTable: "Batchs",
                principalColumn: "UniqueId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
