using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BpstEducation.Migrations
{
    /// <inheritdoc />
    public partial class merge : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicationStatus",
                columns: table => new
                {
                    UniqueId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegistrationStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationStatus", x => x.UniqueId);
                });

            migrationBuilder.CreateTable(
                name: "AppUser",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    UniqueId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    yourName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YourEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.UniqueId);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    UniqueId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.UniqueId);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    UniqueId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IntershipAvailable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.UniqueId);
                });

            migrationBuilder.CreateTable(
                name: "EducationBoardsMaster",
                columns: table => new
                {
                    UniqueId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShortName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationBoardsMaster", x => x.UniqueId);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    UniqueId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JobRole = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Experience = table.Column<int>(type: "int", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LoginIdGuid = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AadhaarNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PanNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Qualification = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.UniqueId);
                });

            migrationBuilder.CreateTable(
                name: "Enquiry",
                columns: table => new
                {
                    UniqueId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AltContactNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enquiry", x => x.UniqueId);
                });

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

            migrationBuilder.CreateTable(
                name: "Subject",
                columns: table => new
                {
                    UniqueId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParentId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subject", x => x.UniqueId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AppUser_UserId",
                        column: x => x.UserId,
                        principalTable: "AppUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AppUser_UserId",
                        column: x => x.UserId,
                        principalTable: "AppUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AppUser_UserId",
                        column: x => x.UserId,
                        principalTable: "AppUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AppUser_UserId",
                        column: x => x.UserId,
                        principalTable: "AppUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "States",
                columns: table => new
                {
                    UniqueId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.UniqueId);
                    table.ForeignKey(
                        name: "FK_States_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "UniqueId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Applications",
                columns: table => new
                {
                    UniqueId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FatherName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    AppliedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MobileNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HRComment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CollegeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HighestQualification = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ErrorLogDuringStudentGenration = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applications", x => x.UniqueId);
                    table.ForeignKey(
                        name: "FK_Applications_ApplicationStatus_StatusId",
                        column: x => x.StatusId,
                        principalTable: "ApplicationStatus",
                        principalColumn: "UniqueId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Applications_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "UniqueId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Batchs",
                columns: table => new
                {
                    UniqueId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Duration = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrainerId = table.Column<int>(type: "int", nullable: false),
                    AssisTrainer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BatchFee = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Batchs", x => x.UniqueId);
                    table.ForeignKey(
                        name: "FK_Batchs_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "UniqueId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Batchs_Employees_TrainerId",
                        column: x => x.TrainerId,
                        principalTable: "Employees",
                        principalColumn: "UniqueId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CodeHelpers",
                columns: table => new
                {
                    UniqueId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubjectId = table.Column<int>(type: "int", nullable: false),
                    Topic = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TopicDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnswerLine1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnswerText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tags = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CodeHelpers", x => x.UniqueId);
                    table.ForeignKey(
                        name: "FK_CodeHelpers_Subject_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subject",
                        principalColumn: "UniqueId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    UniqueId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubjectId = table.Column<int>(type: "int", nullable: false),
                    QustionText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QustionDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnswerLine1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnswerLine2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnswerText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnswerObjectJson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tags = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.UniqueId);
                    table.ForeignKey(
                        name: "FK_Questions_Subject_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subject",
                        principalColumn: "UniqueId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    UniqueId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StateId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.UniqueId);
                    table.ForeignKey(
                        name: "FK_Cities_States_StateId",
                        column: x => x.StateId,
                        principalTable: "States",
                        principalColumn: "UniqueId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    UniqueId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddressLine1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressLine2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressLine3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NearestLandMark = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StateId = table.Column<int>(type: "int", nullable: true),
                    CityId = table.Column<int>(type: "int", nullable: true),
                    CountryId = table.Column<int>(type: "int", nullable: true),
                    PinCode = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.UniqueId);
                    table.ForeignKey(
                        name: "FK_Address_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "UniqueId");
                    table.ForeignKey(
                        name: "FK_Address_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "UniqueId");
                    table.ForeignKey(
                        name: "FK_Address_States_StateId",
                        column: x => x.StateId,
                        principalTable: "States",
                        principalColumn: "UniqueId");
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    UniqueId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressUniqueId = table.Column<int>(type: "int", nullable: true),
                    AadhaarNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PanNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AadharFileUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PanFileUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CourseOfInterestId = table.Column<int>(type: "int", nullable: true),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LoginIdGuid = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicationId = table.Column<int>(type: "int", nullable: true),
                    ErrorLogDuringLoginGenration = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.UniqueId);
                    table.ForeignKey(
                        name: "FK_Students_Address_AddressUniqueId",
                        column: x => x.AddressUniqueId,
                        principalTable: "Address",
                        principalColumn: "UniqueId");
                    table.ForeignKey(
                        name: "FK_Students_Courses_CourseOfInterestId",
                        column: x => x.CourseOfInterestId,
                        principalTable: "Courses",
                        principalColumn: "UniqueId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BatchStudents",
                columns: table => new
                {
                    UniqueId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BatchId = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    DiscountedFeeAmount = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BatchStudents", x => x.UniqueId);
                    table.ForeignKey(
                        name: "FK_BatchStudents_Batchs_BatchId",
                        column: x => x.BatchId,
                        principalTable: "Batchs",
                        principalColumn: "UniqueId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BatchStudents_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "UniqueId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Fees",
                columns: table => new
                {
                    UniqueId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BatchStudentId = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: true),
                    SubmittedFeeAmount = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FeeSubmittingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentMethod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentProofPath = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fees", x => x.UniqueId);
                    table.ForeignKey(
                        name: "FK_Fees_BatchStudents_BatchStudentId",
                        column: x => x.BatchStudentId,
                        principalTable: "BatchStudents",
                        principalColumn: "UniqueId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Fees_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "UniqueId");
                });

            migrationBuilder.InsertData(
                table: "ApplicationStatus",
                columns: new[] { "UniqueId", "CreateDate", "RegistrationStatus" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "New Application" },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Reviewed" },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Admission Taken" },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Not Interested Anymore" }
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7fd3a789-e48b-4ba5-941a-11cbc3b47f39", "a8388c90-9c2b-4260-8cb7-f4250d503afd", "Student", "STUDENT" },
                    { "afa7a44a-e339-453a-8890-c48355bae2ae", "afa7a44a-e339-453a-8890-c48355bae2ae", "Admin", "ADMIN" },
                    { "f7d29f7b-d49f-43b9-834e-7de644eccbcf", "f7d29f7b-d49f-43b9-834e-7de644eccbcf", "Staff", "STAFF" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "UniqueId", "Name" },
                values: new object[] { 1, "India" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "UniqueId", "IntershipAvailable", "Name" },
                values: new object[,]
                {
                    { 1, true, "Programming Classes (for Rising Stars - IX - XII )" },
                    { 2, true, "Software Engineering .Net Internship - 6 months " },
                    { 3, true, "Software Engineering .Net Internship  -  45 days " },
                    { 4, true, "Cyber Security" },
                    { 5, true, " Game Development" },
                    { 6, true, "Hardware / Networking" },
                    { 7, true, "Others" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "UniqueId", "AadhaarNumber", "Address", "DateOfBirth", "Email", "Experience", "FirstName", "JobRole", "LastName", "LoginIdGuid", "PanNumber", "PhoneNumber", "Qualification" },
                values: new object[,]
                {
                    { 1, "999999999999", "Lko", new DateTime(1988, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "arun@bpst.com", 13, "Arul", "Full Stack .Net Dev", "Verma", "", "XXXXX1234X", "9999999999", "MBA" },
                    { 2, "999999999999", "Lko", new DateTime(1998, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "manish@bpst.com", 21, "Manish", "Solution Architech", "Srivastava", "", "XXXXX1234X", "9999999999", "B. Tech" },
                    { 3, "999999999999", "Lko", new DateTime(1990, 2, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "sanjay@bpst.com", 4, "Sanjay", "Junior Developer", "Kumar", "", "XXXXX1234X", "9999999999", "B.Tech" },
                    { 4, "999999999999", "Lko", new DateTime(1999, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "ankit@bpst.com", 11, "Ankit", "Full Stack .Net Dev", "Sahay", "", "XXXXX1234X", "9999999999", "B.Tech" }
                });

            migrationBuilder.InsertData(
                table: "Applications",
                columns: new[] { "UniqueId", "Address", "ApplicationId", "AppliedOn", "CollegeName", "CourseId", "EmailId", "ErrorLogDuringStudentGenration", "FatherName", "FirstName", "HRComment", "HighestQualification", "LastName", "Message", "MobileNumber", "StatusId" },
                values: new object[,]
                {
                    { 1, "Test Address", "Test_01", new DateTime(2024, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "UPTU", 2, "email@gmail.com", "", "Mr. Sanjay Singhania", "User", "", "B.Tech - Coumputer Science & Engineering", "Sir1", "I am dying to get this course at any cost.", "1110171001", 2 },
                    { 2, "Test Address", "Test_02", new DateTime(2024, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "UPTU", 3, "email@gmail.com", "", "Mr. Sanjay Singhania", "User", "", "B.Tech - Coumputer Science & Engineering", "Sir2", "I am dying to get this course at any cost.", "2220272002", 3 },
                    { 3, "Test Address", "Test_03", new DateTime(2024, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "UPTU", 4, "email@gmail.com", "", "Mr. Sanjay Singhania", "User", "", "B.Tech - Coumputer Science & Engineering", "Sir3", "I am dying to get this course at any cost.", "3330373003", 4 },
                    { 4, "Test Address", "Test_04", new DateTime(2024, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "UPTU", 5, "email@gmail.com", "", "Mr. Sanjay Singhania", "User", "", "B.Tech - Coumputer Science & Engineering", "Sir4", "I am dying to get this course at any cost.", "4440474004", 1 },
                    { 5, "Test Address", "Test_05", new DateTime(2024, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "UPTU", 6, "email@gmail.com", "", "Mr. Sanjay Singhania", "User", "", "B.Tech - Coumputer Science & Engineering", "Sir5", "I am dying to get this course at any cost.", "1510571005", 2 },
                    { 6, "Test Address", "Test_06", new DateTime(2024, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "UPTU", 7, "email@gmail.com", "", "Mr. Sanjay Singhania", "User", "", "B.Tech - Coumputer Science & Engineering", "Sir6", "I am dying to get this course at any cost.", "2620672006", 3 },
                    { 7, "Test Address", "Test_07", new DateTime(2024, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "UPTU", 1, "email@gmail.com", "", "Mr. Sanjay Singhania", "User", "", "B.Tech - Coumputer Science & Engineering", "Sir7", "I am dying to get this course at any cost.", "3730773007", 4 },
                    { 8, "Test Address", "Test_08", new DateTime(2024, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "UPTU", 2, "email@gmail.com", "", "Mr. Sanjay Singhania", "User", "", "B.Tech - Coumputer Science & Engineering", "Sir8", "I am dying to get this course at any cost.", "4840174001", 1 },
                    { 9, "Test Address", "Test_09", new DateTime(2024, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "UPTU", 3, "email@gmail.com", "", "Mr. Sanjay Singhania", "User", "", "B.Tech - Coumputer Science & Engineering", "Sir9", "I am dying to get this course at any cost.", "1910271002", 2 },
                    { 10, "Test Address", "Test_010", new DateTime(2024, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "UPTU", 4, "email@gmail.com", "", "Mr. Sanjay Singhania", "User", "", "B.Tech - Coumputer Science & Engineering", "Sir10", "I am dying to get this course at any cost.", "2102037200", 3 },
                    { 11, "Test Address", "Test_011", new DateTime(2024, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "UPTU", 5, "email@gmail.com", "", "Mr. Sanjay Singhania", "User", "", "B.Tech - Coumputer Science & Engineering", "Sir11", "I am dying to get this course at any cost.", "3113047300", 4 },
                    { 12, "Test Address", "Test_012", new DateTime(2024, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "UPTU", 6, "email@gmail.com", "", "Mr. Sanjay Singhania", "User", "", "B.Tech - Coumputer Science & Engineering", "Sir12", "I am dying to get this course at any cost.", "4124057400", 1 },
                    { 13, "Test Address", "Test_013", new DateTime(2024, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "UPTU", 7, "email@gmail.com", "", "Mr. Sanjay Singhania", "User", "", "B.Tech - Coumputer Science & Engineering", "Sir13", "I am dying to get this course at any cost.", "1131067100", 2 },
                    { 14, "Test Address", "Test_014", new DateTime(2024, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "UPTU", 1, "email@gmail.com", "", "Mr. Sanjay Singhania", "User", "", "B.Tech - Coumputer Science & Engineering", "Sir14", "I am dying to get this course at any cost.", "2142077200", 3 },
                    { 15, "Test Address", "Test_015", new DateTime(2024, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "UPTU", 2, "email@gmail.com", "", "Mr. Sanjay Singhania", "User", "", "B.Tech - Coumputer Science & Engineering", "Sir15", "I am dying to get this course at any cost.", "3153017300", 4 },
                    { 16, "Test Address", "Test_016", new DateTime(2024, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "UPTU", 3, "email@gmail.com", "", "Mr. Sanjay Singhania", "User", "", "B.Tech - Coumputer Science & Engineering", "Sir16", "I am dying to get this course at any cost.", "4164027400", 1 },
                    { 17, "Test Address", "Test_017", new DateTime(2024, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "UPTU", 4, "email@gmail.com", "", "Mr. Sanjay Singhania", "User", "", "B.Tech - Coumputer Science & Engineering", "Sir17", "I am dying to get this course at any cost.", "1171037100", 2 },
                    { 18, "Test Address", "Test_018", new DateTime(2024, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "UPTU", 5, "email@gmail.com", "", "Mr. Sanjay Singhania", "User", "", "B.Tech - Coumputer Science & Engineering", "Sir18", "I am dying to get this course at any cost.", "2182047200", 3 },
                    { 19, "Test Address", "Test_019", new DateTime(2024, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "UPTU", 6, "email@gmail.com", "", "Mr. Sanjay Singhania", "User", "", "B.Tech - Coumputer Science & Engineering", "Sir19", "I am dying to get this course at any cost.", "3193057300", 4 },
                    { 20, "Test Address", "Test_020", new DateTime(2024, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "UPTU", 7, "email@gmail.com", "", "Mr. Sanjay Singhania", "User", "", "B.Tech - Coumputer Science & Engineering", "Sir20", "I am dying to get this course at any cost.", "4204067400", 1 },
                    { 21, "Test Address", "Test_021", new DateTime(2024, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "UPTU", 1, "email@gmail.com", "", "Mr. Sanjay Singhania", "User", "", "B.Tech - Coumputer Science & Engineering", "Sir21", "I am dying to get this course at any cost.", "1211077100", 2 },
                    { 22, "Test Address", "Test_022", new DateTime(2024, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "UPTU", 2, "email@gmail.com", "", "Mr. Sanjay Singhania", "User", "", "B.Tech - Coumputer Science & Engineering", "Sir22", "I am dying to get this course at any cost.", "2222017200", 3 },
                    { 23, "Test Address", "Test_023", new DateTime(2024, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "UPTU", 3, "email@gmail.com", "", "Mr. Sanjay Singhania", "User", "", "B.Tech - Coumputer Science & Engineering", "Sir23", "I am dying to get this course at any cost.", "3233027300", 4 },
                    { 24, "Test Address", "Test_024", new DateTime(2024, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "UPTU", 4, "email@gmail.com", "", "Mr. Sanjay Singhania", "User", "", "B.Tech - Coumputer Science & Engineering", "Sir24", "I am dying to get this course at any cost.", "4244037400", 1 },
                    { 25, "Test Address", "Test_025", new DateTime(2024, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "UPTU", 5, "email@gmail.com", "", "Mr. Sanjay Singhania", "User", "", "B.Tech - Coumputer Science & Engineering", "Sir25", "I am dying to get this course at any cost.", "1251047100", 2 },
                    { 26, "Test Address", "Test_026", new DateTime(2024, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "UPTU", 6, "email@gmail.com", "", "Mr. Sanjay Singhania", "User", "", "B.Tech - Coumputer Science & Engineering", "Sir26", "I am dying to get this course at any cost.", "2262057200", 3 },
                    { 27, "Test Address", "Test_027", new DateTime(2024, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "UPTU", 7, "email@gmail.com", "", "Mr. Sanjay Singhania", "User", "", "B.Tech - Coumputer Science & Engineering", "Sir27", "I am dying to get this course at any cost.", "3273067300", 4 },
                    { 28, "Test Address", "Test_028", new DateTime(2024, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "UPTU", 1, "email@gmail.com", "", "Mr. Sanjay Singhania", "User", "", "B.Tech - Coumputer Science & Engineering", "Sir28", "I am dying to get this course at any cost.", "4284077400", 1 },
                    { 29, "Test Address", "Test_029", new DateTime(2024, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "UPTU", 2, "email@gmail.com", "", "Mr. Sanjay Singhania", "User", "", "B.Tech - Coumputer Science & Engineering", "Sir29", "I am dying to get this course at any cost.", "1291017100", 2 },
                    { 30, "Test Address", "Test_030", new DateTime(2024, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "UPTU", 3, "email@gmail.com", "", "Mr. Sanjay Singhania", "User", "", "B.Tech - Coumputer Science & Engineering", "Sir30", "I am dying to get this course at any cost.", "2302027200", 3 },
                    { 31, "Test Address", "Test_031", new DateTime(2024, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "UPTU", 4, "email@gmail.com", "", "Mr. Sanjay Singhania", "User", "", "B.Tech - Coumputer Science & Engineering", "Sir31", "I am dying to get this course at any cost.", "3313037300", 4 },
                    { 32, "Test Address", "Test_032", new DateTime(2024, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "UPTU", 5, "email@gmail.com", "", "Mr. Sanjay Singhania", "User", "", "B.Tech - Coumputer Science & Engineering", "Sir32", "I am dying to get this course at any cost.", "4324047400", 1 },
                    { 33, "Test Address", "Test_033", new DateTime(2024, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "UPTU", 6, "email@gmail.com", "", "Mr. Sanjay Singhania", "User", "", "B.Tech - Coumputer Science & Engineering", "Sir33", "I am dying to get this course at any cost.", "1331057100", 2 },
                    { 34, "Test Address", "Test_034", new DateTime(2024, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "UPTU", 7, "email@gmail.com", "", "Mr. Sanjay Singhania", "User", "", "B.Tech - Coumputer Science & Engineering", "Sir34", "I am dying to get this course at any cost.", "2342067200", 3 },
                    { 35, "Test Address", "Test_035", new DateTime(2024, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "UPTU", 1, "email@gmail.com", "", "Mr. Sanjay Singhania", "User", "", "B.Tech - Coumputer Science & Engineering", "Sir35", "I am dying to get this course at any cost.", "3353077300", 4 },
                    { 36, "Test Address", "Test_036", new DateTime(2024, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "UPTU", 2, "email@gmail.com", "", "Mr. Sanjay Singhania", "User", "", "B.Tech - Coumputer Science & Engineering", "Sir36", "I am dying to get this course at any cost.", "4364017400", 1 },
                    { 37, "Test Address", "Test_037", new DateTime(2024, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "UPTU", 3, "email@gmail.com", "", "Mr. Sanjay Singhania", "User", "", "B.Tech - Coumputer Science & Engineering", "Sir37", "I am dying to get this course at any cost.", "1371027100", 2 },
                    { 38, "Test Address", "Test_038", new DateTime(2024, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "UPTU", 4, "email@gmail.com", "", "Mr. Sanjay Singhania", "User", "", "B.Tech - Coumputer Science & Engineering", "Sir38", "I am dying to get this course at any cost.", "2382037200", 3 },
                    { 39, "Test Address", "Test_039", new DateTime(2024, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "UPTU", 5, "email@gmail.com", "", "Mr. Sanjay Singhania", "User", "", "B.Tech - Coumputer Science & Engineering", "Sir39", "I am dying to get this course at any cost.", "3393047300", 4 },
                    { 40, "Test Address", "Test_040", new DateTime(2024, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "UPTU", 6, "email@gmail.com", "", "Mr. Sanjay Singhania", "User", "", "B.Tech - Coumputer Science & Engineering", "Sir40", "I am dying to get this course at any cost.", "4404057400", 1 },
                    { 41, "Test Address", "Test_041", new DateTime(2024, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "UPTU", 7, "email@gmail.com", "", "Mr. Sanjay Singhania", "User", "", "B.Tech - Coumputer Science & Engineering", "Sir41", "I am dying to get this course at any cost.", "1411067100", 2 },
                    { 42, "Test Address", "Test_042", new DateTime(2024, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "UPTU", 1, "email@gmail.com", "", "Mr. Sanjay Singhania", "User", "", "B.Tech - Coumputer Science & Engineering", "Sir42", "I am dying to get this course at any cost.", "2422077200", 3 },
                    { 43, "Test Address", "Test_043", new DateTime(2024, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "UPTU", 2, "email@gmail.com", "", "Mr. Sanjay Singhania", "User", "", "B.Tech - Coumputer Science & Engineering", "Sir43", "I am dying to get this course at any cost.", "3433017300", 4 },
                    { 44, "Test Address", "Test_044", new DateTime(2024, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "UPTU", 3, "email@gmail.com", "", "Mr. Sanjay Singhania", "User", "", "B.Tech - Coumputer Science & Engineering", "Sir44", "I am dying to get this course at any cost.", "4444027400", 1 },
                    { 45, "Test Address", "Test_045", new DateTime(2024, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "UPTU", 4, "email@gmail.com", "", "Mr. Sanjay Singhania", "User", "", "B.Tech - Coumputer Science & Engineering", "Sir45", "I am dying to get this course at any cost.", "1451037100", 2 },
                    { 46, "Test Address", "Test_046", new DateTime(2024, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "UPTU", 5, "email@gmail.com", "", "Mr. Sanjay Singhania", "User", "", "B.Tech - Coumputer Science & Engineering", "Sir46", "I am dying to get this course at any cost.", "2462047200", 3 },
                    { 47, "Test Address", "Test_047", new DateTime(2024, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "UPTU", 6, "email@gmail.com", "", "Mr. Sanjay Singhania", "User", "", "B.Tech - Coumputer Science & Engineering", "Sir47", "I am dying to get this course at any cost.", "3473057300", 4 },
                    { 48, "Test Address", "Test_048", new DateTime(2024, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "UPTU", 7, "email@gmail.com", "", "Mr. Sanjay Singhania", "User", "", "B.Tech - Coumputer Science & Engineering", "Sir48", "I am dying to get this course at any cost.", "4484067400", 1 },
                    { 49, "Test Address", "Test_049", new DateTime(2024, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "UPTU", 1, "email@gmail.com", "", "Mr. Sanjay Singhania", "User", "", "B.Tech - Coumputer Science & Engineering", "Sir49", "I am dying to get this course at any cost.", "1491077100", 2 },
                    { 50, "Test Address", "Test_050", new DateTime(2024, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "UPTU", 2, "email@gmail.com", "", "Mr. Sanjay Singhania", "User", "", "B.Tech - Coumputer Science & Engineering", "Sir50", "I am dying to get this course at any cost.", "2502017200", 3 },
                    { 51, "Test Address", "Test_051", new DateTime(2024, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "UPTU", 3, "email@gmail.com", "", "Mr. Sanjay Singhania", "User", "", "B.Tech - Coumputer Science & Engineering", "Sir51", "I am dying to get this course at any cost.", "3513027300", 4 },
                    { 52, "Test Address", "Test_052", new DateTime(2024, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "UPTU", 4, "email@gmail.com", "", "Mr. Sanjay Singhania", "User", "", "B.Tech - Coumputer Science & Engineering", "Sir52", "I am dying to get this course at any cost.", "4524037400", 1 },
                    { 53, "Test Address", "Test_053", new DateTime(2024, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "UPTU", 5, "email@gmail.com", "", "Mr. Sanjay Singhania", "User", "", "B.Tech - Coumputer Science & Engineering", "Sir53", "I am dying to get this course at any cost.", "1531047100", 2 },
                    { 54, "Test Address", "Test_054", new DateTime(2024, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "UPTU", 6, "email@gmail.com", "", "Mr. Sanjay Singhania", "User", "", "B.Tech - Coumputer Science & Engineering", "Sir54", "I am dying to get this course at any cost.", "2542057200", 3 },
                    { 55, "Test Address", "Test_055", new DateTime(2024, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "UPTU", 7, "email@gmail.com", "", "Mr. Sanjay Singhania", "User", "", "B.Tech - Coumputer Science & Engineering", "Sir55", "I am dying to get this course at any cost.", "3553067300", 4 },
                    { 56, "Test Address", "Test_056", new DateTime(2024, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "UPTU", 1, "email@gmail.com", "", "Mr. Sanjay Singhania", "User", "", "B.Tech - Coumputer Science & Engineering", "Sir56", "I am dying to get this course at any cost.", "4564077400", 1 },
                    { 57, "Test Address", "Test_057", new DateTime(2024, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "UPTU", 2, "email@gmail.com", "", "Mr. Sanjay Singhania", "User", "", "B.Tech - Coumputer Science & Engineering", "Sir57", "I am dying to get this course at any cost.", "1571017100", 2 },
                    { 58, "Test Address", "Test_058", new DateTime(2024, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "UPTU", 3, "email@gmail.com", "", "Mr. Sanjay Singhania", "User", "", "B.Tech - Coumputer Science & Engineering", "Sir58", "I am dying to get this course at any cost.", "2582027200", 3 },
                    { 59, "Test Address", "Test_059", new DateTime(2024, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "UPTU", 4, "email@gmail.com", "", "Mr. Sanjay Singhania", "User", "", "B.Tech - Coumputer Science & Engineering", "Sir59", "I am dying to get this course at any cost.", "3593037300", 4 },
                    { 60, "Test Address", "Test_060", new DateTime(2024, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "UPTU", 5, "email@gmail.com", "", "Mr. Sanjay Singhania", "User", "", "B.Tech - Coumputer Science & Engineering", "Sir60", "I am dying to get this course at any cost.", "4604047400", 1 },
                    { 61, "Test Address", "Test_061", new DateTime(2024, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "UPTU", 6, "email@gmail.com", "", "Mr. Sanjay Singhania", "User", "", "B.Tech - Coumputer Science & Engineering", "Sir61", "I am dying to get this course at any cost.", "1611057100", 2 },
                    { 62, "Test Address", "Test_062", new DateTime(2024, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "UPTU", 7, "email@gmail.com", "", "Mr. Sanjay Singhania", "User", "", "B.Tech - Coumputer Science & Engineering", "Sir62", "I am dying to get this course at any cost.", "2622067200", 3 },
                    { 63, "Test Address", "Test_063", new DateTime(2024, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "UPTU", 1, "email@gmail.com", "", "Mr. Sanjay Singhania", "User", "", "B.Tech - Coumputer Science & Engineering", "Sir63", "I am dying to get this course at any cost.", "3633077300", 4 },
                    { 64, "Test Address", "Test_064", new DateTime(2024, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "UPTU", 2, "email@gmail.com", "", "Mr. Sanjay Singhania", "User", "", "B.Tech - Coumputer Science & Engineering", "Sir64", "I am dying to get this course at any cost.", "4644017400", 1 },
                    { 65, "Test Address", "Test_065", new DateTime(2024, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "UPTU", 3, "email@gmail.com", "", "Mr. Sanjay Singhania", "User", "", "B.Tech - Coumputer Science & Engineering", "Sir65", "I am dying to get this course at any cost.", "1651027100", 2 },
                    { 66, "Test Address", "Test_066", new DateTime(2024, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "UPTU", 4, "email@gmail.com", "", "Mr. Sanjay Singhania", "User", "", "B.Tech - Coumputer Science & Engineering", "Sir66", "I am dying to get this course at any cost.", "2662037200", 3 },
                    { 67, "Test Address", "Test_067", new DateTime(2024, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "UPTU", 5, "email@gmail.com", "", "Mr. Sanjay Singhania", "User", "", "B.Tech - Coumputer Science & Engineering", "Sir67", "I am dying to get this course at any cost.", "3673047300", 4 },
                    { 68, "Test Address", "Test_068", new DateTime(2024, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "UPTU", 6, "email@gmail.com", "", "Mr. Sanjay Singhania", "User", "", "B.Tech - Coumputer Science & Engineering", "Sir68", "I am dying to get this course at any cost.", "4684057400", 1 },
                    { 69, "Test Address", "Test_069", new DateTime(2024, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "UPTU", 7, "email@gmail.com", "", "Mr. Sanjay Singhania", "User", "", "B.Tech - Coumputer Science & Engineering", "Sir69", "I am dying to get this course at any cost.", "1691067100", 2 },
                    { 70, "Test Address", "Test_070", new DateTime(2024, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "UPTU", 1, "email@gmail.com", "", "Mr. Sanjay Singhania", "User", "", "B.Tech - Coumputer Science & Engineering", "Sir70", "I am dying to get this course at any cost.", "2702077200", 3 },
                    { 71, "Test Address", "Test_071", new DateTime(2024, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "UPTU", 2, "email@gmail.com", "", "Mr. Sanjay Singhania", "User", "", "B.Tech - Coumputer Science & Engineering", "Sir71", "I am dying to get this course at any cost.", "3713017300", 4 },
                    { 72, "Test Address", "Test_072", new DateTime(2024, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "UPTU", 3, "email@gmail.com", "", "Mr. Sanjay Singhania", "User", "", "B.Tech - Coumputer Science & Engineering", "Sir72", "I am dying to get this course at any cost.", "4724027400", 1 },
                    { 73, "Test Address", "Test_073", new DateTime(2024, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "UPTU", 4, "email@gmail.com", "", "Mr. Sanjay Singhania", "User", "", "B.Tech - Coumputer Science & Engineering", "Sir73", "I am dying to get this course at any cost.", "1731037100", 2 },
                    { 74, "Test Address", "Test_074", new DateTime(2024, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "UPTU", 5, "email@gmail.com", "", "Mr. Sanjay Singhania", "User", "", "B.Tech - Coumputer Science & Engineering", "Sir74", "I am dying to get this course at any cost.", "2742047200", 3 },
                    { 75, "Test Address", "Test_075", new DateTime(2024, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "UPTU", 6, "email@gmail.com", "", "Mr. Sanjay Singhania", "User", "", "B.Tech - Coumputer Science & Engineering", "Sir75", "I am dying to get this course at any cost.", "3753057300", 4 },
                    { 76, "Test Address", "Test_076", new DateTime(2024, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "UPTU", 7, "email@gmail.com", "", "Mr. Sanjay Singhania", "User", "", "B.Tech - Coumputer Science & Engineering", "Sir76", "I am dying to get this course at any cost.", "4764067400", 1 },
                    { 77, "Test Address", "Test_077", new DateTime(2024, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "UPTU", 1, "email@gmail.com", "", "Mr. Sanjay Singhania", "User", "", "B.Tech - Coumputer Science & Engineering", "Sir77", "I am dying to get this course at any cost.", "1771077100", 2 },
                    { 78, "Test Address", "Test_078", new DateTime(2024, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "UPTU", 2, "email@gmail.com", "", "Mr. Sanjay Singhania", "User", "", "B.Tech - Coumputer Science & Engineering", "Sir78", "I am dying to get this course at any cost.", "2782017200", 3 },
                    { 79, "Test Address", "Test_079", new DateTime(2024, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "UPTU", 3, "email@gmail.com", "", "Mr. Sanjay Singhania", "User", "", "B.Tech - Coumputer Science & Engineering", "Sir79", "I am dying to get this course at any cost.", "3793027300", 4 },
                    { 80, "Test Address", "Test_080", new DateTime(2024, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "UPTU", 4, "email@gmail.com", "", "Mr. Sanjay Singhania", "User", "", "B.Tech - Coumputer Science & Engineering", "Sir80", "I am dying to get this course at any cost.", "4804037400", 1 },
                    { 81, "Test Address", "Test_081", new DateTime(2024, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "UPTU", 5, "email@gmail.com", "", "Mr. Sanjay Singhania", "User", "", "B.Tech - Coumputer Science & Engineering", "Sir81", "I am dying to get this course at any cost.", "1811047100", 2 },
                    { 82, "Test Address", "Test_082", new DateTime(2024, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "UPTU", 6, "email@gmail.com", "", "Mr. Sanjay Singhania", "User", "", "B.Tech - Coumputer Science & Engineering", "Sir82", "I am dying to get this course at any cost.", "2822057200", 3 },
                    { 83, "Test Address", "Test_083", new DateTime(2024, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "UPTU", 7, "email@gmail.com", "", "Mr. Sanjay Singhania", "User", "", "B.Tech - Coumputer Science & Engineering", "Sir83", "I am dying to get this course at any cost.", "3833067300", 4 },
                    { 84, "Test Address", "Test_084", new DateTime(2024, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "UPTU", 1, "email@gmail.com", "", "Mr. Sanjay Singhania", "User", "", "B.Tech - Coumputer Science & Engineering", "Sir84", "I am dying to get this course at any cost.", "4844077400", 1 },
                    { 85, "Test Address", "Test_085", new DateTime(2024, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "UPTU", 2, "email@gmail.com", "", "Mr. Sanjay Singhania", "User", "", "B.Tech - Coumputer Science & Engineering", "Sir85", "I am dying to get this course at any cost.", "1851017100", 2 },
                    { 86, "Test Address", "Test_086", new DateTime(2024, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "UPTU", 3, "email@gmail.com", "", "Mr. Sanjay Singhania", "User", "", "B.Tech - Coumputer Science & Engineering", "Sir86", "I am dying to get this course at any cost.", "2862027200", 3 },
                    { 87, "Test Address", "Test_087", new DateTime(2024, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "UPTU", 4, "email@gmail.com", "", "Mr. Sanjay Singhania", "User", "", "B.Tech - Coumputer Science & Engineering", "Sir87", "I am dying to get this course at any cost.", "3873037300", 4 },
                    { 88, "Test Address", "Test_088", new DateTime(2024, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "UPTU", 5, "email@gmail.com", "", "Mr. Sanjay Singhania", "User", "", "B.Tech - Coumputer Science & Engineering", "Sir88", "I am dying to get this course at any cost.", "4884047400", 1 },
                    { 89, "Test Address", "Test_089", new DateTime(2024, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "UPTU", 6, "email@gmail.com", "", "Mr. Sanjay Singhania", "User", "", "B.Tech - Coumputer Science & Engineering", "Sir89", "I am dying to get this course at any cost.", "1891057100", 2 },
                    { 90, "Test Address", "Test_090", new DateTime(2024, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "UPTU", 7, "email@gmail.com", "", "Mr. Sanjay Singhania", "User", "", "B.Tech - Coumputer Science & Engineering", "Sir90", "I am dying to get this course at any cost.", "2902067200", 3 },
                    { 91, "Test Address", "Test_091", new DateTime(2024, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "UPTU", 1, "email@gmail.com", "", "Mr. Sanjay Singhania", "User", "", "B.Tech - Coumputer Science & Engineering", "Sir91", "I am dying to get this course at any cost.", "3913077300", 4 },
                    { 92, "Test Address", "Test_092", new DateTime(2024, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "UPTU", 2, "email@gmail.com", "", "Mr. Sanjay Singhania", "User", "", "B.Tech - Coumputer Science & Engineering", "Sir92", "I am dying to get this course at any cost.", "4924017400", 1 },
                    { 93, "Test Address", "Test_093", new DateTime(2024, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "UPTU", 3, "email@gmail.com", "", "Mr. Sanjay Singhania", "User", "", "B.Tech - Coumputer Science & Engineering", "Sir93", "I am dying to get this course at any cost.", "1931027100", 2 },
                    { 94, "Test Address", "Test_094", new DateTime(2024, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "UPTU", 4, "email@gmail.com", "", "Mr. Sanjay Singhania", "User", "", "B.Tech - Coumputer Science & Engineering", "Sir94", "I am dying to get this course at any cost.", "2942037200", 3 },
                    { 95, "Test Address", "Test_095", new DateTime(2024, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "UPTU", 5, "email@gmail.com", "", "Mr. Sanjay Singhania", "User", "", "B.Tech - Coumputer Science & Engineering", "Sir95", "I am dying to get this course at any cost.", "3953047300", 4 },
                    { 96, "Test Address", "Test_096", new DateTime(2024, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "UPTU", 6, "email@gmail.com", "", "Mr. Sanjay Singhania", "User", "", "B.Tech - Coumputer Science & Engineering", "Sir96", "I am dying to get this course at any cost.", "4964057400", 1 },
                    { 97, "Test Address", "Test_097", new DateTime(2024, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "UPTU", 7, "email@gmail.com", "", "Mr. Sanjay Singhania", "User", "", "B.Tech - Coumputer Science & Engineering", "Sir97", "I am dying to get this course at any cost.", "1971067100", 2 },
                    { 98, "Test Address", "Test_098", new DateTime(2024, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "UPTU", 1, "email@gmail.com", "", "Mr. Sanjay Singhania", "User", "", "B.Tech - Coumputer Science & Engineering", "Sir98", "I am dying to get this course at any cost.", "2982077200", 3 },
                    { 99, "Test Address", "Test_099", new DateTime(2024, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "UPTU", 2, "email@gmail.com", "", "Mr. Sanjay Singhania", "User", "", "B.Tech - Coumputer Science & Engineering", "Sir99", "I am dying to get this course at any cost.", "3993017300", 4 },
                    { 100, "Test Address", "Test_0100", new DateTime(2024, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "UPTU", 3, "email@gmail.com", "", "Mr. Sanjay Singhania", "User", "", "B.Tech - Coumputer Science & Engineering", "Sir100", "I am dying to get this course at any cost.", "4100402740", 1 },
                    { 101, "Test Address", "Test_0101", new DateTime(2024, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "UPTU", 4, "email@gmail.com", "", "Mr. Sanjay Singhania", "User", "", "B.Tech - Coumputer Science & Engineering", "Sir101", "I am dying to get this course at any cost.", "1101103710", 2 },
                    { 102, "Test Address", "Test_0102", new DateTime(2024, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "UPTU", 5, "email@gmail.com", "", "Mr. Sanjay Singhania", "User", "", "B.Tech - Coumputer Science & Engineering", "Sir102", "I am dying to get this course at any cost.", "2102204720", 3 },
                    { 103, "Test Address", "Test_0103", new DateTime(2024, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "UPTU", 6, "email@gmail.com", "", "Mr. Sanjay Singhania", "User", "", "B.Tech - Coumputer Science & Engineering", "Sir103", "I am dying to get this course at any cost.", "3103305730", 4 },
                    { 104, "Test Address", "Test_0104", new DateTime(2024, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "UPTU", 7, "email@gmail.com", "", "Mr. Sanjay Singhania", "User", "", "B.Tech - Coumputer Science & Engineering", "Sir104", "I am dying to get this course at any cost.", "4104406740", 1 },
                    { 105, "Test Address", "Test_0105", new DateTime(2024, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "UPTU", 1, "email@gmail.com", "", "Mr. Sanjay Singhania", "User", "", "B.Tech - Coumputer Science & Engineering", "Sir105", "I am dying to get this course at any cost.", "1105107710", 2 },
                    { 106, "Test Address", "Test_0106", new DateTime(2024, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "UPTU", 2, "email@gmail.com", "", "Mr. Sanjay Singhania", "User", "", "B.Tech - Coumputer Science & Engineering", "Sir106", "I am dying to get this course at any cost.", "2106201720", 3 },
                    { 107, "Test Address", "Test_0107", new DateTime(2024, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "UPTU", 3, "email@gmail.com", "", "Mr. Sanjay Singhania", "User", "", "B.Tech - Coumputer Science & Engineering", "Sir107", "I am dying to get this course at any cost.", "3107302730", 4 },
                    { 108, "Test Address", "Test_0108", new DateTime(2024, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "UPTU", 4, "email@gmail.com", "", "Mr. Sanjay Singhania", "User", "", "B.Tech - Coumputer Science & Engineering", "Sir108", "I am dying to get this course at any cost.", "4108403740", 1 },
                    { 109, "Test Address", "Test_0109", new DateTime(2024, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "UPTU", 5, "email@gmail.com", "", "Mr. Sanjay Singhania", "User", "", "B.Tech - Coumputer Science & Engineering", "Sir109", "I am dying to get this course at any cost.", "1109104710", 2 },
                    { 110, "Test Address", "Test_0110", new DateTime(2024, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "UPTU", 6, "email@gmail.com", "", "Mr. Sanjay Singhania", "User", "", "B.Tech - Coumputer Science & Engineering", "Sir110", "I am dying to get this course at any cost.", "2110205720", 3 },
                    { 111, "Test Address", "Test_0111", new DateTime(2024, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "UPTU", 7, "email@gmail.com", "", "Mr. Sanjay Singhania", "User", "", "B.Tech - Coumputer Science & Engineering", "Sir111", "I am dying to get this course at any cost.", "3111306730", 4 },
                    { 112, "Test Address", "Test_0112", new DateTime(2024, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "UPTU", 1, "email@gmail.com", "", "Mr. Sanjay Singhania", "User", "", "B.Tech - Coumputer Science & Engineering", "Sir112", "I am dying to get this course at any cost.", "4112407740", 1 },
                    { 113, "Test Address", "Test_0113", new DateTime(2024, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "UPTU", 2, "email@gmail.com", "", "Mr. Sanjay Singhania", "User", "", "B.Tech - Coumputer Science & Engineering", "Sir113", "I am dying to get this course at any cost.", "1113101710", 2 },
                    { 114, "Test Address", "Test_0114", new DateTime(2024, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "UPTU", 3, "email@gmail.com", "", "Mr. Sanjay Singhania", "User", "", "B.Tech - Coumputer Science & Engineering", "Sir114", "I am dying to get this course at any cost.", "2114202720", 3 },
                    { 115, "Test Address", "Test_0115", new DateTime(2024, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "UPTU", 4, "email@gmail.com", "", "Mr. Sanjay Singhania", "User", "", "B.Tech - Coumputer Science & Engineering", "Sir115", "I am dying to get this course at any cost.", "3115303730", 4 },
                    { 116, "Test Address", "Test_0116", new DateTime(2024, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "UPTU", 5, "email@gmail.com", "", "Mr. Sanjay Singhania", "User", "", "B.Tech - Coumputer Science & Engineering", "Sir116", "I am dying to get this course at any cost.", "4116404740", 1 },
                    { 117, "Test Address", "Test_0117", new DateTime(2024, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "UPTU", 6, "email@gmail.com", "", "Mr. Sanjay Singhania", "User", "", "B.Tech - Coumputer Science & Engineering", "Sir117", "I am dying to get this course at any cost.", "1117105710", 2 },
                    { 118, "Test Address", "Test_0118", new DateTime(2024, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "UPTU", 7, "email@gmail.com", "", "Mr. Sanjay Singhania", "User", "", "B.Tech - Coumputer Science & Engineering", "Sir118", "I am dying to get this course at any cost.", "2118206720", 3 },
                    { 119, "Test Address", "Test_0119", new DateTime(2024, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "UPTU", 1, "email@gmail.com", "", "Mr. Sanjay Singhania", "User", "", "B.Tech - Coumputer Science & Engineering", "Sir119", "I am dying to get this course at any cost.", "3119307730", 4 },
                    { 120, "Test Address", "Test_0120", new DateTime(2024, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "UPTU", 2, "email@gmail.com", "", "Mr. Sanjay Singhania", "User", "", "B.Tech - Coumputer Science & Engineering", "Sir120", "I am dying to get this course at any cost.", "4120401740", 1 },
                    { 121, "Test Address", "Test_0121", new DateTime(2024, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "UPTU", 3, "email@gmail.com", "", "Mr. Sanjay Singhania", "User", "", "B.Tech - Coumputer Science & Engineering", "Sir121", "I am dying to get this course at any cost.", "1121102710", 2 }
                });

            migrationBuilder.InsertData(
                table: "Batchs",
                columns: new[] { "UniqueId", "AssisTrainer", "BatchFee", "CourseId", "CreatedDate", "Description", "Duration", "LastUpdatedDate", "StartDateTime", "Title", "TrainerId" },
                values: new object[,]
                {
                    { 1, "", 3000, 3, new DateTime(2024, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "45 Days", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "DotNet Internship ", 2 },
                    { 2, "", 18000, 2, new DateTime(2024, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "6 - Months", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 21, 11, 0, 0, 0, DateTimeKind.Unspecified), "DotNet Industrial Training 6 Months - Morning", 1 },
                    { 3, "", 18000, 2, new DateTime(2024, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "6 - Months", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 4, 9, 0, 0, 0, DateTimeKind.Unspecified), "DotNet Industrial Training 6 Months - Evening", 3 },
                    { 4, "", 1000, 1, new DateTime(2024, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "1 Month", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rising Stars", 3 },
                    { 5, "", 800, 7, new DateTime(2024, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "1 Month", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Other Crash Course - Per Month", 4 }
                });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "UniqueId", "CountryId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Andaman and Nicobar Islands" },
                    { 2, 1, "Andhra Pradesh" },
                    { 3, 1, "Arunachal Pradesh" },
                    { 4, 1, "Assam" },
                    { 5, 1, "Bihar" },
                    { 6, 1, "Chandigarh" },
                    { 7, 1, "Chhattisgarh" },
                    { 8, 1, "Dadra and Nagar Haveli" },
                    { 9, 1, "Delhi" },
                    { 10, 1, "Goa" },
                    { 11, 1, "Gujarat" },
                    { 12, 1, "Haryana" },
                    { 13, 1, "Himachal Pradesh" },
                    { 14, 1, "Jammu and Kashmir" },
                    { 15, 1, "Jharkhand" },
                    { 16, 1, "Karnataka" },
                    { 17, 1, "Karnatka" },
                    { 18, 1, "Kerala" },
                    { 19, 1, "Madhya Pradesh" },
                    { 20, 1, "Maharashtra" },
                    { 21, 1, "Manipur" },
                    { 22, 1, "Meghalaya" },
                    { 23, 1, "Mizoram" },
                    { 24, 1, "Nagaland" },
                    { 25, 1, "Odisha" },
                    { 26, 1, "Puducherry" },
                    { 27, 1, "Punjab" },
                    { 28, 1, "Rajasthan" },
                    { 29, 1, "Tamil Nadu" },
                    { 30, 1, "Telangana" },
                    { 31, 1, "Tripura" },
                    { 32, 1, " Uttar Pradesh" },
                    { 33, 1, "Uttarakhand" },
                    { 34, 1, "West Bengal" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "UniqueId", "Name", "StateId" },
                values: new object[,]
                {
                    { 1, "Port Blai", 1 },
                    { 2, "Yemmiganu", 2 },
                    { 3, "Kadir", 2 },
                    { 4, "Rajampe", 2 },
                    { 5, "Tadpatr", 2 },
                    { 6, "Tadepalligude", 2 },
                    { 7, "Chilakaluripe", 2 },
                    { 8, "Chiral", 2 },
                    { 9, "Anakapall", 2 },
                    { 10, "Kaval", 2 },
                    { 11, "Palacol", 2 },
                    { 12, "Sullurpet", 2 },
                    { 13, "Tanuk", 2 },
                    { 14, "Rayachot", 2 },
                    { 15, "Srikalahast", 2 },
                    { 16, "Bapatl", 2 },
                    { 17, "Naidupe", 2 },
                    { 18, "Nagar", 2 },
                    { 19, "Gudu", 2 },
                    { 20, "Vinukond", 2 },
                    { 21, "Narasapura", 2 },
                    { 22, "Nuzvi", 2 },
                    { 23, "Markapu", 2 },
                    { 24, "Ponnu", 2 },
                    { 25, "Kanduku", 2 },
                    { 26, "Bobbil", 2 },
                    { 27, "Rayadur", 2 },
                    { 28, "Visakhapatna", 2 },
                    { 29, "Vijayawad", 2 },
                    { 30, "Guntu", 2 },
                    { 31, "Nellor", 2 },
                    { 32, "Kurnoo", 2 },
                    { 33, "Rajahmundr", 2 },
                    { 34, "Kakinad", 2 },
                    { 35, "Tirupat", 2 },
                    { 36, "Anantapu", 2 },
                    { 37, "Kadap", 2 },
                    { 38, "Vizianagara", 2 },
                    { 39, "Elur", 2 },
                    { 40, "Ongol", 2 },
                    { 41, "Nandya", 2 },
                    { 42, "Machilipatna", 2 },
                    { 43, "Adon", 2 },
                    { 44, "Tenal", 2 },
                    { 45, "Chittoo", 2 },
                    { 46, "Hindupu", 2 },
                    { 47, "Proddatu", 2 },
                    { 48, "Bhimavara", 2 },
                    { 49, "Madanapall", 2 },
                    { 50, "Guntaka", 2 },
                    { 51, "Dharmavara", 2 },
                    { 52, "Gudivad", 2 },
                    { 53, "Srikakula", 2 },
                    { 54, "Narasaraope", 2 },
                    { 55, "Samalko", 2 },
                    { 56, "Jaggaiahpe", 2 },
                    { 57, "Tun", 2 },
                    { 58, "Amalapura", 2 },
                    { 59, "Bheemunipatna", 2 },
                    { 60, "Sattenapall", 2 },
                    { 61, "Venkatagir", 2 },
                    { 62, "Pithapura", 2 },
                    { 63, "Palasa Kasibugg", 2 },
                    { 64, "Parvathipura", 2 },
                    { 65, "Goot", 2 },
                    { 66, "Salu", 2 },
                    { 67, "Macherl", 2 },
                    { 68, "Mandapet", 2 },
                    { 69, "Jammalamadug", 2 },
                    { 70, "Peddapura", 2 },
                    { 71, "Punganu", 2 },
                    { 72, "Nidadavol", 2 },
                    { 73, "Repall", 2 },
                    { 74, "Ramachandrapura", 2 },
                    { 75, "Kovvu", 2 },
                    { 76, "Tiruvur", 2 },
                    { 77, "Uravakond", 2 },
                    { 78, "Narsipatna", 2 },
                    { 79, "Yerraguntl", 2 },
                    { 80, "Pedan", 2 },
                    { 81, "Puttu", 2 },
                    { 82, "Renigunt", 2 },
                    { 83, "Raja", 2 },
                    { 84, "Srisailam Project (Right Flank Colony) Townshi", 2 },
                    { 85, "Pasigha", 3 },
                    { 86, "Naharlagu", 3 },
                    { 87, "Lank", 4 },
                    { 88, "Barpet", 4 },
                    { 89, "Goalpar", 4 },
                    { 90, "Silapatha", 4 },
                    { 91, "Margherit", 4 },
                    { 92, "Mangaldo", 4 },
                    { 93, "Rangi", 4 },
                    { 94, "Mankacha", 4 },
                    { 95, "Lumdin", 4 },
                    { 96, "Nalbar", 4 },
                    { 97, "Nagao", 4 },
                    { 98, "Dibrugar", 4 },
                    { 99, "Silcha", 4 },
                    { 100, "Guwahat", 4 },
                    { 101, "Sibsaga", 4 },
                    { 102, "Karimgan", 4 },
                    { 103, "Tezpu", 4 },
                    { 104, "North Lakhimpu", 4 },
                    { 105, "Diph", 4 },
                    { 106, "Dhubr", 4 },
                    { 107, "Jorha", 4 },
                    { 108, "Bongaigaon Cit", 4 },
                    { 109, "Tinsuki", 4 },
                    { 110, "Marian", 4 },
                    { 111, "Marigao", 4 },
                    { 112, "Maharajgan", 5 },
                    { 113, "Sila", 5 },
                    { 114, "Asargan", 5 },
                    { 115, "Bar", 5 },
                    { 116, "Lakhisara", 5 },
                    { 117, "Nawad", 5 },
                    { 118, "Aurangaba", 5 },
                    { 119, "Buxa", 5 },
                    { 120, "Jehanaba", 5 },
                    { 121, "Jamalpu", 5 },
                    { 122, "Kishangan", 5 },
                    { 123, "Siwa", 5 },
                    { 124, "Arari", 5 },
                    { 125, "Jamu", 5 },
                    { 126, "Sitamarh", 5 },
                    { 127, "Gopalgan", 5 },
                    { 128, "Masaurh", 5 },
                    { 129, "Madhuban", 5 },
                    { 130, "Samastipu", 5 },
                    { 131, "Mokame", 5 },
                    { 132, "Dumrao", 5 },
                    { 133, "Supau", 5 },
                    { 134, "Patn", 5 },
                    { 135, "Chhapr", 5 },
                    { 136, "Begusara", 5 },
                    { 137, "Arra", 5 },
                    { 138, "Darbhang", 5 },
                    { 139, "Bhagalpu", 5 },
                    { 140, "Muzaffarpu", 5 },
                    { 141, "Gay", 5 },
                    { 142, "Purni", 5 },
                    { 143, "Munge", 5 },
                    { 144, "Katiha", 5 },
                    { 145, "Sahars", 5 },
                    { 146, "Dehri-on-Son", 5 },
                    { 147, "Bettia", 5 },
                    { 148, "Sasara", 5 },
                    { 149, "Hajipu", 5 },
                    { 150, "Bagah", 5 },
                    { 151, "Motihar", 5 },
                    { 152, "Roser", 5 },
                    { 153, "Nokh", 5 },
                    { 154, "Sugaul", 5 },
                    { 155, "Makhdumpu", 5 },
                    { 156, "Mane", 5 },
                    { 157, "Rafigan", 5 },
                    { 158, "Marhaur", 5 },
                    { 159, "Pir", 5 },
                    { 160, "Mirgan", 5 },
                    { 161, "Lalgan", 5 },
                    { 162, "Murligan", 5 },
                    { 163, "Motipu", 5 },
                    { 164, "Manihar", 5 },
                    { 165, "Sheoha", 5 },
                    { 166, "Arwa", 5 },
                    { 167, "Forbesgan", 5 },
                    { 168, "BhabUrban Agglomeratio", 5 },
                    { 169, "Narkatiagan", 5 },
                    { 170, "Naugachhi", 5 },
                    { 171, "Sheikhpur", 5 },
                    { 172, "Sultangan", 5 },
                    { 173, "Raxaul Baza", 5 },
                    { 174, "Madhepur", 5 },
                    { 175, "Mahnar Baza", 5 },
                    { 176, "Ramnaga", 5 },
                    { 177, "Rajgi", 5 },
                    { 178, "Sonepu", 5 },
                    { 179, "Sherghat", 5 },
                    { 180, "Warisaligan", 5 },
                    { 181, "Revelgan", 5 },
                    { 182, "Chandigar", 6 },
                    { 183, "Bhilai Naga", 7 },
                    { 184, "Raipu", 7 },
                    { 185, "Bilaspu", 7 },
                    { 186, "Korb", 7 },
                    { 187, "Dur", 7 },
                    { 188, "Jagdalpu", 7 },
                    { 189, "Ambikapu", 7 },
                    { 190, "Raigar", 7 },
                    { 191, "Rajnandgao", 7 },
                    { 192, "Bhatapar", 7 },
                    { 193, "Chirmir", 7 },
                    { 194, "Mahasamun", 7 },
                    { 195, "Dhamtar", 7 },
                    { 196, "Naila Janjgi", 7 },
                    { 197, "Dalli-Rajhar", 7 },
                    { 198, "Manendragar", 7 },
                    { 199, "Mungel", 7 },
                    { 200, "Tilda Newr", 7 },
                    { 201, "Sakt", 7 },
                    { 202, "Silvass", 8 },
                    { 203, "New Delh", 9 },
                    { 204, "Delh", 9 },
                    { 205, "Marmaga", 10 },
                    { 206, "Panaj", 10 },
                    { 207, "Marga", 10 },
                    { 208, "Mapus", 10 },
                    { 209, "Padr", 11 },
                    { 210, "Vyar", 11 },
                    { 211, "Lunawad", 11 },
                    { 212, "Vap", 11 },
                    { 213, "Umret", 11 },
                    { 214, "Rajpipl", 11 },
                    { 215, "Sanan", 11 },
                    { 216, "Rajul", 11 },
                    { 217, "Siho", 11 },
                    { 218, "Mandv", 11 },
                    { 219, "Thangad", 11 },
                    { 220, "Wankane", 11 },
                    { 221, "Limbd", 11 },
                    { 222, "Kapadvan", 11 },
                    { 223, "Petla", 11 },
                    { 224, "Palitan", 11 },
                    { 225, "Lath", 11 },
                    { 226, "Rapa", 11 },
                    { 227, "Songad", 11 },
                    { 228, "Vijapu", 11 },
                    { 229, "Pard", 11 },
                    { 230, "Radhanpu", 11 },
                    { 231, "Mahemdaba", 11 },
                    { 232, "Ranava", 11 },
                    { 233, "Salay", 11 },
                    { 234, "Manavada", 11 },
                    { 235, "Talaj", 11 },
                    { 236, "Vadnaga", 11 },
                    { 237, "Thara", 11 },
                    { 238, "Mans", 11 },
                    { 239, "Umbergao", 11 },
                    { 240, "Amrel", 11 },
                    { 241, "Dees", 11 },
                    { 242, "Dhoraj", 11 },
                    { 243, "Khambha", 11 },
                    { 244, "Mahuv", 11 },
                    { 245, "Anja", 11 },
                    { 246, "Wadhwa", 11 },
                    { 247, "Kesho", 11 },
                    { 248, "Ankleshwa", 11 },
                    { 249, "Savarkundl", 11 },
                    { 250, "Kad", 11 },
                    { 251, "Visnaga", 11 },
                    { 252, "Uplet", 11 },
                    { 253, "Un", 11 },
                    { 254, "Sidhpu", 11 },
                    { 255, "Modas", 11 },
                    { 256, "Viramga", 11 },
                    { 257, "Unjh", 11 },
                    { 258, "Mangro", 11 },
                    { 259, "Ahmedaba", 11 },
                    { 260, "Vadodar", 11 },
                    { 261, "Sura", 11 },
                    { 262, "Rajko", 11 },
                    { 263, "Bhavnaga", 11 },
                    { 264, "Jamnaga", 11 },
                    { 265, "Godhr", 11 },
                    { 266, "Palanpu", 11 },
                    { 267, "Bhu", 11 },
                    { 268, "Valsa", 11 },
                    { 269, "Pata", 11 },
                    { 270, "Verava", 11 },
                    { 271, "Vap", 11 },
                    { 272, "Navsar", 11 },
                    { 273, "Bharuc", 11 },
                    { 274, "Mahesan", 11 },
                    { 275, "Nadia", 11 },
                    { 276, "Anan", 11 },
                    { 277, "Porbanda", 11 },
                    { 278, "Morv", 11 },
                    { 279, "Chhapr", 11 },
                    { 280, "Adala", 11 },
                    { 281, "Sarso", 12 },
                    { 282, "Rani", 12 },
                    { 283, "Bhiwan", 12 },
                    { 284, "Yamunanaga", 12 },
                    { 285, "Panchkul", 12 },
                    { 286, "Sonipa", 12 },
                    { 287, "Bahadurgar", 12 },
                    { 288, "Jin", 12 },
                    { 289, "Sirs", 12 },
                    { 290, "Thanesa", 12 },
                    { 291, "Kaitha", 12 },
                    { 292, "Palwa", 12 },
                    { 293, "Gurgao", 12 },
                    { 294, "Faridaba", 12 },
                    { 295, "Hisa", 12 },
                    { 296, "Rohta", 12 },
                    { 297, "Panipa", 12 },
                    { 298, "Karna", 12 },
                    { 299, "Mandi Dabwal", 12 },
                    { 300, "Gohan", 12 },
                    { 301, "Narwan", 12 },
                    { 302, "Tohan", 12 },
                    { 303, "Fatehaba", 12 },
                    { 304, "Narnau", 12 },
                    { 305, "Hans", 12 },
                    { 306, "Rewar", 12 },
                    { 307, "Ladw", 12 },
                    { 308, "Sohn", 12 },
                    { 309, "Safido", 12 },
                    { 310, "Taraor", 12 },
                    { 311, "Pinjor", 12 },
                    { 312, "Samalkh", 12 },
                    { 313, "Rati", 12 },
                    { 314, "Mahendragar", 12 },
                    { 315, "Charkhi Dadr", 12 },
                    { 316, "Pehow", 12 },
                    { 317, "Shahba", 12 },
                    { 318, "Sola", 13 },
                    { 319, "Sundarnaga", 13 },
                    { 320, "Palampu", 13 },
                    { 321, "Naha", 13 },
                    { 322, "Mand", 13 },
                    { 323, "Shiml", 13 },
                    { 324, "Baramul", 14 },
                    { 325, "Jamm", 14 },
                    { 326, "Srinaga", 14 },
                    { 327, "Sopor", 14 },
                    { 328, "Anantna", 14 },
                    { 329, "Udhampu", 14 },
                    { 330, "KathUrban Agglomeratio", 14 },
                    { 331, "Rajaur", 14 },
                    { 332, "Punc", 14 },
                    { 333, "Madhupu", 15 },
                    { 334, "Chirkund", 15 },
                    { 335, "Chatr", 15 },
                    { 336, "Dumk", 15 },
                    { 337, "Gumi", 15 },
                    { 338, "Simdeg", 15 },
                    { 339, "Musaban", 15 },
                    { 340, "Mihija", 15 },
                    { 341, "Pakau", 15 },
                    { 342, "Patrat", 15 },
                    { 343, "Lohardag", 15 },
                    { 344, "Tenu dam-cum-Kathhar", 15 },
                    { 345, "Ramgar", 15 },
                    { 346, "Saund", 15 },
                    { 347, "Jhumri Tilaiy", 15 },
                    { 348, "Sahibgan", 15 },
                    { 349, "Medininagar (Daltonganj", 15 },
                    { 350, "Chaibas", 15 },
                    { 351, "Dhanba", 15 },
                    { 352, "Ranch", 15 },
                    { 353, "Jamshedpu", 15 },
                    { 354, "Bokaro Steel Cit", 15 },
                    { 355, "Phusr", 15 },
                    { 356, "Adityapu", 15 },
                    { 357, "Deogha", 15 },
                    { 358, "Hazariba", 15 },
                    { 359, "Giridi", 15 },
                    { 360, "Chikkamagalur", 16 },
                    { 361, "Udup", 16 },
                    { 362, "Mandy", 16 },
                    { 363, "Kola", 16 },
                    { 364, "Raayachur", 16 },
                    { 365, "Robertson Pe", 16 },
                    { 366, "Davanager", 16 },
                    { 367, "Belagav", 16 },
                    { 368, "Mangalur", 16 },
                    { 369, "Ballar", 16 },
                    { 370, "Shivamogg", 16 },
                    { 371, "Tumku", 16 },
                    { 372, "Hubli-Dharwa", 16 },
                    { 373, "Bengalur", 16 },
                    { 374, "Rabkavi Banhatt", 16 },
                    { 375, "Shahaba", 16 },
                    { 376, "Sirs", 16 },
                    { 377, "Tiptu", 16 },
                    { 378, "Sindhnu", 16 },
                    { 379, "Yadgi", 16 },
                    { 380, "Ramanagara", 16 },
                    { 381, "Goka", 16 },
                    { 382, "Karwa", 16 },
                    { 383, "Ranebennur", 16 },
                    { 384, "Ranibennu", 16 },
                    { 385, "Ro", 16 },
                    { 386, "Srinivaspu", 16 },
                    { 387, "Sakaleshapur", 16 },
                    { 388, "Shiggao", 16 },
                    { 389, "Sindag", 16 },
                    { 390, "Shrirangapattan", 16 },
                    { 391, "Mudabidr", 16 },
                    { 392, "Navalgun", 16 },
                    { 393, "Magad", 16 },
                    { 394, "Talikot", 16 },
                    { 395, "Mahalingapur", 16 },
                    { 396, "Seda", 16 },
                    { 397, "Shikaripu", 16 },
                    { 398, "Mudalag", 16 },
                    { 399, "Muddebiha", 16 },
                    { 400, "Pavagad", 16 },
                    { 401, "Sindhag", 16 },
                    { 402, "Sandur", 16 },
                    { 403, "Malu", 16 },
                    { 404, "Terda", 16 },
                    { 405, "Maddu", 16 },
                    { 406, "Madhugir", 16 },
                    { 407, "Tekkalakot", 16 },
                    { 408, "Afzalpu", 16 },
                    { 409, "Nargun", 16 },
                    { 410, "Tariker", 16 },
                    { 411, "Malavall", 16 },
                    { 412, "Lakshmeshwa", 16 },
                    { 413, "Ramdur", 16 },
                    { 414, "Nelamangal", 16 },
                    { 415, "Manv", 16 },
                    { 416, "Shahpu", 16 },
                    { 417, "Saundatti-Yellamm", 16 },
                    { 418, "Wad", 16 },
                    { 419, "Sidlaghatt", 16 },
                    { 420, "Sankeshwar", 16 },
                    { 421, "Madiker", 16 },
                    { 422, "Savanu", 16 },
                    { 423, "Lingsugu", 16 },
                    { 424, "Vijayapur", 16 },
                    { 425, "Puttu", 16 },
                    { 426, "Sir", 16 },
                    { 427, "Arsiker", 16 },
                    { 428, "Sagar", 16 },
                    { 429, "Nanjangu", 16 },
                    { 430, "Athn", 16 },
                    { 431, "Sirugupp", 16 },
                    { 432, "Mudho", 16 },
                    { 433, "Mulbaga", 16 },
                    { 434, "Surapur", 16 },
                    { 435, "Sadalag", 16 },
                    { 436, "Mundarg", 16 },
                    { 437, "Adya", 16 },
                    { 438, "Piriyapatn", 16 },
                    { 439, "Mysor", 17 },
                    { 440, "Thrissu", 18 },
                    { 441, "Kolla", 18 },
                    { 442, "Kozhikod", 18 },
                    { 443, "Thiruvananthapura", 18 },
                    { 444, "Koch", 18 },
                    { 445, "Alappuzh", 18 },
                    { 446, "Palakka", 18 },
                    { 447, "Malappura", 18 },
                    { 448, "Ponnan", 18 },
                    { 449, "Taliparamb", 18 },
                    { 450, "Kanhanga", 18 },
                    { 451, "Vatakar", 18 },
                    { 452, "Nedumanga", 18 },
                    { 453, "Ottappala", 18 },
                    { 454, "Kunnamkula", 18 },
                    { 455, "Kottaya", 18 },
                    { 456, "Kasarago", 18 },
                    { 457, "Kannu", 18 },
                    { 458, "Tiru", 18 },
                    { 459, "Kayamkula", 18 },
                    { 460, "Koyiland", 18 },
                    { 461, "Neyyattinkar", 18 },
                    { 462, "Shoranu", 18 },
                    { 463, "Cherthal", 18 },
                    { 464, "Nilambu", 18 },
                    { 465, "Punalu", 18 },
                    { 466, "Perinthalmann", 18 },
                    { 467, "Mattannu", 18 },
                    { 468, "Thodupuzh", 18 },
                    { 469, "Thiruvall", 18 },
                    { 470, "Changanasser", 18 },
                    { 471, "Chalakud", 18 },
                    { 472, "Kodungallu", 18 },
                    { 473, "Pappinisser", 18 },
                    { 474, "Varkal", 18 },
                    { 475, "Pathanamthitt", 18 },
                    { 476, "Paravoo", 18 },
                    { 477, "Attinga", 18 },
                    { 478, "Peringathu", 18 },
                    { 479, "Perumbavoo", 18 },
                    { 480, "Mavelikkar", 18 },
                    { 481, "Mavoo", 18 },
                    { 482, "Muvattupuzh", 18 },
                    { 483, "Adoo", 18 },
                    { 484, "Chittur-Thathamangala", 18 },
                    { 485, "Vaiko", 18 },
                    { 486, "Pala", 18 },
                    { 487, "Puthuppall", 18 },
                    { 488, "Panamatto", 18 },
                    { 489, "Guruvayoo", 18 },
                    { 490, "Panniyannu", 18 },
                    { 491, "Ra", 19 },
                    { 492, "Pal", 19 },
                    { 493, "Pachor", 19 },
                    { 494, "Mhowgao", 19 },
                    { 495, "Narsinghgar", 19 },
                    { 496, "Vijaypu", 19 },
                    { 497, "Manas", 19 },
                    { 498, "Nainpu", 19 },
                    { 499, "Prithvipu", 19 },
                    { 500, "Sohagpu", 19 },
                    { 501, "Maugan", 19 },
                    { 502, "Shamgar", 19 },
                    { 503, "Maharajpu", 19 },
                    { 504, "Multa", 19 },
                    { 505, "Nowrozabad (Khodargama", 19 },
                    { 506, "Niwar", 19 },
                    { 507, "Sausa", 19 },
                    { 508, "Rajgar", 19 },
                    { 509, "Taran", 19 },
                    { 510, "Wara Seon", 19 },
                    { 511, "Rahatgar", 19 },
                    { 512, "Panaga", 19 },
                    { 513, "Manawa", 19 },
                    { 514, "Malaj Khan", 19 },
                    { 515, "Sarangpu", 19 },
                    { 516, "Narsinghgar", 19 },
                    { 517, "Mahidpu", 19 },
                    { 518, "Pasa", 19 },
                    { 519, "Mund", 19 },
                    { 520, "Nepanaga", 19 },
                    { 521, "Seoni-Malw", 19 },
                    { 522, "Rehl", 19 },
                    { 523, "Raise", 19 },
                    { 524, "Laha", 19 },
                    { 525, "Sihor", 19 },
                    { 526, "Nowgon", 19 },
                    { 527, "Mandidee", 19 },
                    { 528, "Umari", 19 },
                    { 529, "Pors", 19 },
                    { 530, "Sanawa", 19 },
                    { 531, "Sabalgar", 19 },
                    { 532, "Maiha", 19 },
                    { 533, "Raghogarh-Vijaypu", 19 },
                    { 534, "Sendhw", 19 },
                    { 535, "Pann", 19 },
                    { 536, "Pipariy", 19 },
                    { 537, "Sidh", 19 },
                    { 538, "Siron", 19 },
                    { 539, "Pandhurn", 19 },
                    { 540, "Shujalpu", 19 },
                    { 541, "Pithampu", 19 },
                    { 542, "Alirajpu", 19 },
                    { 543, "Mandl", 19 },
                    { 544, "Sheopu", 19 },
                    { 545, "Shajapu", 19 },
                    { 546, "Shahdo", 19 },
                    { 547, "Tikamgar", 19 },
                    { 548, "Balagha", 19 },
                    { 549, "Ashok Naga", 19 },
                    { 550, "Seon", 19 },
                    { 551, "Sarn", 19 },
                    { 552, "Sehor", 19 },
                    { 553, "Mhow Cantonmen", 19 },
                    { 554, "Itars", 19 },
                    { 555, "Nagd", 19 },
                    { 556, "Singraul", 19 },
                    { 557, "Moren", 19 },
                    { 558, "Murwara (Katni", 19 },
                    { 559, "Satn", 19 },
                    { 560, "Rew", 19 },
                    { 561, "Mandsau", 19 },
                    { 562, "Neemuc", 19 },
                    { 563, "Vidish", 19 },
                    { 564, "Shivpur", 19 },
                    { 565, "Ganjbasod", 19 },
                    { 566, "Ujjai", 19 },
                    { 567, "Indor", 19 },
                    { 568, "Jabalpu", 19 },
                    { 569, "Gwalio", 19 },
                    { 570, "Bhopa", 19 },
                    { 571, "Saga", 19 },
                    { 572, "Ratla", 19 },
                    { 573, "Ichalkaranj", 20 },
                    { 574, "Parbhan", 20 },
                    { 575, "Akol", 20 },
                    { 576, "Malegao", 20 },
                    { 577, "Nanded-Waghal", 20 },
                    { 578, "Ahmednaga", 20 },
                    { 579, "Latu", 20 },
                    { 580, "Dhul", 20 },
                    { 581, "Kalyan-Dombival", 20 },
                    { 582, "Vasai-Vira", 20 },
                    { 583, "Nashi", 20 },
                    { 584, "Than", 20 },
                    { 585, "Mumba", 20 },
                    { 586, "Nagpu", 20 },
                    { 587, "Pun", 20 },
                    { 588, "Sangl", 20 },
                    { 589, "Mira-Bhayanda", 20 },
                    { 590, "Amravat", 20 },
                    { 591, "Bhiwand", 20 },
                    { 592, "Solapu", 20 },
                    { 593, "Yavatma", 20 },
                    { 594, "Panve", 20 },
                    { 595, "Amalne", 20 },
                    { 596, "Shrirampu", 20 },
                    { 597, "Ako", 20 },
                    { 598, "Pandharpu", 20 },
                    { 599, "Aurangaba", 20 },
                    { 600, "Wardh", 20 },
                    { 601, "Udgi", 20 },
                    { 602, "Nandurba", 20 },
                    { 603, "Achalpu", 20 },
                    { 604, "Osmanaba", 20 },
                    { 605, "Satar", 20 },
                    { 606, "Parl", 20 },
                    { 607, "Washi", 20 },
                    { 608, "Manma", 20 },
                    { 609, "Ambejoga", 20 },
                    { 610, "Lonavl", 20 },
                    { 611, "Wan", 20 },
                    { 612, "Shirpur-Warwad", 20 },
                    { 613, "Malkapu", 20 },
                    { 614, "Talegaon Dabhad", 20 },
                    { 615, "Anjangao", 20 },
                    { 616, "Umre", 20 },
                    { 617, "Sangamne", 20 },
                    { 618, "Uran Islampu", 20 },
                    { 619, "Pusa", 20 },
                    { 620, "Ratnagir", 20 },
                    { 621, "Arv", 20 },
                    { 622, "Manjlegao", 20 },
                    { 623, "Sillo", 20 },
                    { 624, "Wadgaon Roa", 20 },
                    { 625, "Nandur", 20 },
                    { 626, "Waror", 20 },
                    { 627, "Pachor", 20 },
                    { 628, "Tumsa", 20 },
                    { 629, "Palgha", 20 },
                    { 630, "Shegao", 20 },
                    { 631, "Phalta", 20 },
                    { 632, "Oza", 20 },
                    { 633, "Shahad", 20 },
                    { 634, "Yevl", 20 },
                    { 635, "Vit", 20 },
                    { 636, "Umarkhe", 20 },
                    { 637, "Nawapu", 20 },
                    { 638, "Tuljapu", 20 },
                    { 639, "Paitha", 20 },
                    { 640, "Rahur", 20 },
                    { 641, "Nilang", 20 },
                    { 642, "Umarg", 20 },
                    { 643, "Purn", 20 },
                    { 644, "Morsh", 20 },
                    { 645, "Sail", 20 },
                    { 646, "Vaijapu", 20 },
                    { 647, "Tasgao", 20 },
                    { 648, "Murtijapu", 20 },
                    { 649, "Wa", 20 },
                    { 650, "Pulgao", 20 },
                    { 651, "Yawa", 20 },
                    { 652, "Mehka", 20 },
                    { 653, "Mukhe", 20 },
                    { 654, "Rave", 20 },
                    { 655, "Talod", 20 },
                    { 656, "Shrigond", 20 },
                    { 657, "Shird", 20 },
                    { 658, "Pandharkaod", 20 },
                    { 659, "Shiru", 20 },
                    { 660, "Savne", 20 },
                    { 661, "Sasva", 20 },
                    { 662, "Sangol", 20 },
                    { 663, "Partu", 20 },
                    { 664, "Mangrulpi", 20 },
                    { 665, "Riso", 20 },
                    { 666, "Karja", 20 },
                    { 667, "Pe", 20 },
                    { 668, "Ura", 20 },
                    { 669, "Manwat", 20 },
                    { 670, "Satan", 20 },
                    { 671, "Sinna", 20 },
                    { 672, "Pathr", 20 },
                    { 673, "Uchgao", 20 },
                    { 674, "Rajur", 20 },
                    { 675, "Vadgaon Kasb", 20 },
                    { 676, "Tiror", 20 },
                    { 677, "Maha", 20 },
                    { 678, "Lona", 20 },
                    { 679, "Soyagao", 20 },
                    { 680, "Mangalvedh", 20 },
                    { 681, "Sawantwad", 20 },
                    { 682, "Pathard", 20 },
                    { 683, "Mu", 20 },
                    { 684, "Ramte", 20 },
                    { 685, "Paun", 20 },
                    { 686, "Nandgao", 20 },
                    { 687, "Loh", 20 },
                    { 688, "Waru", 20 },
                    { 689, "Mhaswa", 20 },
                    { 690, "Patu", 20 },
                    { 691, "Narkhe", 20 },
                    { 692, "Shendurjan", 20 },
                    { 693, "Mayang Impha", 21 },
                    { 694, "Lilon", 21 },
                    { 695, "Thouba", 21 },
                    { 696, "Impha", 21 },
                    { 697, "Shillon", 22 },
                    { 698, "Tur", 22 },
                    { 699, "Nongstoi", 22 },
                    { 700, "Lungle", 23 },
                    { 701, "Aizaw", 23 },
                    { 702, "Saih", 23 },
                    { 703, "Dimapu", 24 },
                    { 704, "Kohim", 24 },
                    { 705, "Mokokchun", 24 },
                    { 706, "Zunhebot", 24 },
                    { 707, "Tuensan", 24 },
                    { 708, "Wokh", 24 },
                    { 709, "Phulaban", 25 },
                    { 710, "Pattamunda", 25 },
                    { 711, "Sundargar", 25 },
                    { 712, "Kendrapar", 25 },
                    { 713, "Talche", 25 },
                    { 714, "Rajagangapu", 25 },
                    { 715, "Parlakhemund", 25 },
                    { 716, "Byasanaga", 25 },
                    { 717, "Titlagar", 25 },
                    { 718, "Nabarangapu", 25 },
                    { 719, "Sor", 25 },
                    { 720, "Malkangir", 25 },
                    { 721, "Rairangpu", 25 },
                    { 722, "Balangi", 25 },
                    { 723, "Jharsugud", 25 },
                    { 724, "Bhadra", 25 },
                    { 725, "Baripada Tow", 25 },
                    { 726, "Paradi", 25 },
                    { 727, "Bargar", 25 },
                    { 728, "Jatan", 25 },
                    { 729, "Kendujha", 25 },
                    { 730, "Sunabed", 25 },
                    { 731, "Rayagad", 25 },
                    { 732, "Bhawanipatn", 25 },
                    { 733, "Barbi", 25 },
                    { 734, "Dhenkana", 25 },
                    { 735, "Baleshwar Tow", 25 },
                    { 736, "Sambalpu", 25 },
                    { 737, "Pur", 25 },
                    { 738, "Brahmapu", 25 },
                    { 739, "Raurkel", 25 },
                    { 740, "Bhubaneswa", 25 },
                    { 741, "Cuttac", 25 },
                    { 742, "Tarbh", 25 },
                    { 743, "Pondicherr", 26 },
                    { 744, "Yana", 26 },
                    { 745, "Karaika", 26 },
                    { 746, "Mah", 26 },
                    { 747, "Zir", 27 },
                    { 748, "Nakoda", 27 },
                    { 749, "Nanga", 27 },
                    { 750, "Patt", 27 },
                    { 751, "Sirhind Fatehgarh Sahi", 27 },
                    { 752, "Jalandhar Cantt", 27 },
                    { 753, "Rupnaga", 27 },
                    { 754, "Firozpur Cantt", 27 },
                    { 755, "Saman", 27 },
                    { 756, "Nawanshah", 27 },
                    { 757, "Rampura Phu", 27 },
                    { 758, "Qadia", 27 },
                    { 759, "Sujanpu", 27 },
                    { 760, "Pattra", 27 },
                    { 761, "Mukeria", 27 },
                    { 762, "Morinda, Indi", 27 },
                    { 763, "Phillau", 27 },
                    { 764, "Urmar Tand", 27 },
                    { 765, "Longowa", 27 },
                    { 766, "Raiko", 27 },
                    { 767, "Faridko", 27 },
                    { 768, "Muktsa", 27 },
                    { 769, "Rajpur", 27 },
                    { 770, "Mans", 27 },
                    { 771, "Gobindgar", 27 },
                    { 772, "Khara", 27 },
                    { 773, "Gurdaspu", 27 },
                    { 774, "Sangru", 27 },
                    { 775, "Fazilk", 27 },
                    { 776, "Firozpu", 27 },
                    { 777, "Phagwar", 27 },
                    { 778, "Kapurthal", 27 },
                    { 779, "Zirakpu", 27 },
                    { 780, "Kot Kapur", 27 },
                    { 781, "Dhur", 27 },
                    { 782, "Suna", 27 },
                    { 783, "Nabh", 27 },
                    { 784, "Tarn Tara", 27 },
                    { 785, "Malou", 27 },
                    { 786, "Jagrao", 27 },
                    { 787, "Bathind", 27 },
                    { 788, "Jalandha", 27 },
                    { 789, "Amritsa", 27 },
                    { 790, "Patial", 27 },
                    { 791, "Ludhian", 27 },
                    { 792, "Batal", 27 },
                    { 793, "Pathanko", 27 },
                    { 794, "Hoshiarpu", 27 },
                    { 795, "Mohal", 27 },
                    { 796, "Barnal", 27 },
                    { 797, "Mog", 27 },
                    { 798, "Khann", 27 },
                    { 799, "Malerkotl", 27 },
                    { 800, "Talwar", 27 },
                    { 801, "Takhatgar", 28 },
                    { 802, "Pindwar", 28 },
                    { 803, "Mandalgar", 28 },
                    { 804, "Mandaw", 28 },
                    { 805, "Sadulpu", 28 },
                    { 806, "Ton", 28 },
                    { 807, "Sika", 28 },
                    { 808, "Barme", 28 },
                    { 809, "Jodhpu", 28 },
                    { 810, "Jaipu", 28 },
                    { 811, "Bikane", 28 },
                    { 812, "Udaipu", 28 },
                    { 813, "Bharatpu", 28 },
                    { 814, "Pal", 28 },
                    { 815, "Ajme", 28 },
                    { 816, "Bhilwar", 28 },
                    { 817, "Alwa", 28 },
                    { 818, "Ladn", 28 },
                    { 819, "Nimbaher", 28 },
                    { 820, "Ratangar", 28 },
                    { 821, "Nokh", 28 },
                    { 822, "Rajsaman", 28 },
                    { 823, "Suratgar", 28 },
                    { 824, "Makran", 28 },
                    { 825, "Nagau", 28 },
                    { 826, "Sawai Madhopu", 28 },
                    { 827, "Sardarshaha", 28 },
                    { 828, "Sujangar", 28 },
                    { 829, "Sheogan", 28 },
                    { 830, "Rajgarh (Alwar", 28 },
                    { 831, "Naga", 28 },
                    { 832, "Sadr", 28 },
                    { 833, "Todaraising", 28 },
                    { 834, "Sambha", 28 },
                    { 835, "Pranti", 28 },
                    { 836, "Sadulshaha", 28 },
                    { 837, "Todabhi", 28 },
                    { 838, "Reengu", 28 },
                    { 839, "Rajaldesa", 28 },
                    { 840, "Phuler", 28 },
                    { 841, "Mount Ab", 28 },
                    { 842, "Mangro", 28 },
                    { 843, "Shahpur", 28 },
                    { 844, "Raisinghnaga", 28 },
                    { 845, "Rawatsa", 28 },
                    { 846, "Rajakher", 28 },
                    { 847, "Shahpur", 28 },
                    { 848, "Malpur", 28 },
                    { 849, "Nadba", 28 },
                    { 850, "Sanchor", 28 },
                    { 851, "Lakher", 28 },
                    { 852, "Losa", 28 },
                    { 853, "Sri Madhopu", 28 },
                    { 854, "Ramngar", 28 },
                    { 855, "Udaipurwat", 28 },
                    { 856, "Sagwar", 28 },
                    { 857, "Ramganj Mand", 28 },
                    { 858, "Sumerpu", 28 },
                    { 859, "Vijainagar, Ajme", 28 },
                    { 860, "Phalod", 28 },
                    { 861, "Nathdwar", 28 },
                    { 862, "Lachhmangar", 28 },
                    { 863, "Nasiraba", 28 },
                    { 864, "Rajgarh (Churu", 28 },
                    { 865, "Noha", 28 },
                    { 866, "Rawatbhat", 28 },
                    { 867, "Sangari", 28 },
                    { 868, "Pratapgar", 28 },
                    { 869, "Siroh", 28 },
                    { 870, "Lalso", 28 },
                    { 871, "Pipar Cit", 28 },
                    { 872, "Taranaga", 28 },
                    { 873, "Pilibang", 28 },
                    { 874, "Pilan", 28 },
                    { 875, "Merta Cit", 28 },
                    { 876, "Soja", 28 },
                    { 877, "Neem-Ka-Than", 28 },
                    { 878, "Perambalu", 29 },
                    { 879, "Tiruvethipura", 29 },
                    { 880, "Rameshwara", 29 },
                    { 881, "Sivagang", 29 },
                    { 882, "Vadalu", 29 },
                    { 883, "Vellakoi", 29 },
                    { 884, "Sathyamangala", 29 },
                    { 885, "Puliyankud", 29 },
                    { 886, "Nanjikotta", 29 },
                    { 887, "Thuraiyu", 29 },
                    { 888, "Vedaranya", 29 },
                    { 889, "Usilampatt", 29 },
                    { 890, "Thirumangala", 29 },
                    { 891, "Periyakula", 29 },
                    { 892, "Pernampatt", 29 },
                    { 893, "Nandivaram-Guduvancher", 29 },
                    { 894, "Tiruttan", 29 },
                    { 895, "Rasipura", 29 },
                    { 896, "Nellikuppa", 29 },
                    { 897, "Vikramasingapura", 29 },
                    { 898, "Periyasemu", 29 },
                    { 899, "Tiruchendu", 29 },
                    { 900, "Sattu", 29 },
                    { 901, "Sirkal", 29 },
                    { 902, "Vandavas", 29 },
                    { 903, "Uthamapalaya", 29 },
                    { 904, "Vadakkuvalliyu", 29 },
                    { 905, "Tirukalukundra", 29 },
                    { 906, "Tharamangala", 29 },
                    { 907, "Tirukkoyilu", 29 },
                    { 908, "Oddanchatra", 29 },
                    { 909, "Pallada", 29 },
                    { 910, "Manachanallu", 29 },
                    { 911, "Tirupathu", 29 },
                    { 912, "Shenkotta", 29 },
                    { 913, "Vadipatt", 29 },
                    { 914, "Sholingu", 29 },
                    { 915, "Suranda", 29 },
                    { 916, "Sankar", 29 },
                    { 917, "Suriyampalaya", 29 },
                    { 918, "O' Valle", 29 },
                    { 919, "Thammampatt", 29 },
                    { 920, "Sholavanda", 29 },
                    { 921, "Namagiripetta", 29 },
                    { 922, "Tittakud", 29 },
                    { 923, "Pacod", 29 },
                    { 924, "Tharangambad", 29 },
                    { 925, "Natha", 29 },
                    { 926, "Unnamalaikada", 29 },
                    { 927, "P.N.Patt", 29 },
                    { 928, "Thiruthuraipoond", 29 },
                    { 929, "Pallapatt", 29 },
                    { 930, "Ponner", 29 },
                    { 931, "Lalgud", 29 },
                    { 932, "Viswanatha", 29 },
                    { 933, "Polu", 29 },
                    { 934, "Panagud", 29 },
                    { 935, "Uthirameru", 29 },
                    { 936, "Paramakud", 29 },
                    { 937, "Udhagamandala", 29 },
                    { 938, "Aruppukkotta", 29 },
                    { 939, "Arakkona", 29 },
                    { 940, "Tindivana", 29 },
                    { 941, "Virudhunaga", 29 },
                    { 942, "Virudhachala", 29 },
                    { 943, "Srivilliputhu", 29 },
                    { 944, "Nagapattina", 29 },
                    { 945, "Neyveli (TS", 29 },
                    { 946, "Pudukkotta", 29 },
                    { 947, "Tiruchengod", 29 },
                    { 948, "Viluppura", 29 },
                    { 949, "Theni Allinagara", 29 },
                    { 950, "Vaniyambad", 29 },
                    { 951, "Thiruvaru", 29 },
                    { 952, "Gobichettipalaya", 29 },
                    { 953, "Udumalaipetta", 29 },
                    { 954, "Panrut", 29 },
                    { 955, "Namakka", 29 },
                    { 956, "Thiruvallu", 29 },
                    { 957, "Ramanathapura", 29 },
                    { 958, "Pattukkotta", 29 },
                    { 959, "Tirupathu", 29 },
                    { 960, "Sankarankovi", 29 },
                    { 961, "Tenkas", 29 },
                    { 962, "Karu", 29 },
                    { 963, "Valpara", 29 },
                    { 964, "Palan", 29 },
                    { 965, "Tirunelvel", 29 },
                    { 966, "Tiruppu", 29 },
                    { 967, "Ranipe", 29 },
                    { 968, "Tiruchirappall", 29 },
                    { 969, "Coimbator", 29 },
                    { 970, "Sale", 29 },
                    { 971, "Madura", 29 },
                    { 972, "Chenna", 29 },
                    { 973, "Vellor", 29 },
                    { 974, "Nagercoi", 29 },
                    { 975, "Thanjavu", 29 },
                    { 976, "Kancheepura", 29 },
                    { 977, "Erod", 29 },
                    { 978, "Rajapalaya", 29 },
                    { 979, "Sivakas", 29 },
                    { 980, "Pollach", 29 },
                    { 981, "Tiruvannamala", 29 },
                    { 982, "Pallikond", 29 },
                    { 983, "Peravuran", 29 },
                    { 984, "Parangipetta", 29 },
                    { 985, "Pudupattina", 29 },
                    { 986, "Punjaipugalu", 29 },
                    { 987, "Sivagir", 29 },
                    { 988, "Thirupuvana", 29 },
                    { 989, "Padmanabhapura", 29 },
                    { 990, "Mancheria", 30 },
                    { 991, "Adilaba", 30 },
                    { 992, "Mahbubnaga", 30 },
                    { 993, "Khamma", 30 },
                    { 994, "Hyderaba", 30 },
                    { 995, "Waranga", 30 },
                    { 996, "Ramagunda", 30 },
                    { 997, "Karimnaga", 30 },
                    { 998, "Nizamaba", 30 },
                    { 999, "Koratl", 30 },
                    { 1000, "Palwanch", 30 },
                    { 1001, "Tandu", 30 },
                    { 1002, "Sircill", 30 },
                    { 1003, "Mandamarr", 30 },
                    { 1004, "Siddipe", 30 },
                    { 1005, "Sangaredd", 30 },
                    { 1006, "Bellampall", 30 },
                    { 1007, "Wanaparth", 30 },
                    { 1008, "Kagaznaga", 30 },
                    { 1009, "Gadwa", 30 },
                    { 1010, "Miryalagud", 30 },
                    { 1011, "Jagtia", 30 },
                    { 1012, "Suryape", 30 },
                    { 1013, "Bodha", 30 },
                    { 1014, "Nirma", 30 },
                    { 1015, "Kamaredd", 30 },
                    { 1016, "Kothagude", 30 },
                    { 1017, "Nagarkurnoo", 30 },
                    { 1018, "Farooqnaga", 30 },
                    { 1019, "Meda", 30 },
                    { 1020, "Narayanpe", 30 },
                    { 1021, "Bhongi", 30 },
                    { 1022, "Vikaraba", 30 },
                    { 1023, "Jangao", 30 },
                    { 1024, "Bhains", 30 },
                    { 1025, "Bhadrachala", 30 },
                    { 1026, "Kyathampall", 30 },
                    { 1027, "Manugur", 30 },
                    { 1028, "Yelland", 30 },
                    { 1029, "Sadasivpe", 30 },
                    { 1030, "Udaipu", 31 },
                    { 1031, "Pratapgar", 31 },
                    { 1032, "Dharmanaga", 31 },
                    { 1033, "Agartal", 31 },
                    { 1034, "Beloni", 31 },
                    { 1035, "Khowa", 31 },
                    { 1036, "Kailasaha", 31 },
                    { 1037, "Pithoragar", 33 },
                    { 1038, "Ramnaga", 33 },
                    { 1039, "Nainita", 33 },
                    { 1040, "Manglau", 33 },
                    { 1041, "Sitargan", 33 },
                    { 1042, "Nagl", 33 },
                    { 1043, "Paur", 33 },
                    { 1044, "Tehr", 33 },
                    { 1045, "Mussoori", 33 },
                    { 1046, "Rudrapu", 33 },
                    { 1047, "Rishikes", 33 },
                    { 1048, "Srinaga", 33 },
                    { 1049, "Kashipu", 33 },
                    { 1050, "Roorke", 33 },
                    { 1051, "Haldwani-cum-Kathgoda", 33 },
                    { 1052, "Hardwa", 33 },
                    { 1053, "Dehradu", 33 },
                    { 1054, "Bageshwa", 33 },
                    { 1055, "Adr", 34 },
                    { 1056, "Srirampor", 34 },
                    { 1057, "Monoharpu", 34 },
                    { 1058, "Mathabhang", 34 },
                    { 1059, "Asanso", 34 },
                    { 1060, "Siligur", 34 },
                    { 1061, "Kolkat", 34 },
                    { 1062, "Kharagpu", 34 },
                    { 1063, "Raghunathgan", 34 },
                    { 1064, "Naihat", 34 },
                    { 1065, "English Baza", 34 },
                    { 1066, "Baharampu", 34 },
                    { 1067, "Hugli-Chinsura", 34 },
                    { 1068, "Raigan", 34 },
                    { 1069, "Jalpaigur", 34 },
                    { 1070, "Puruli", 34 },
                    { 1071, "Darjilin", 34 },
                    { 1072, "Nabadwi", 34 },
                    { 1073, "Medinipu", 34 },
                    { 1074, "Habr", 34 },
                    { 1075, "Santipu", 34 },
                    { 1076, "Balurgha", 34 },
                    { 1077, "Ranagha", 34 },
                    { 1078, "Bankur", 34 },
                    { 1079, "Tamlu", 34 },
                    { 1080, "AlipurdUrban Agglomeration", 34 },
                    { 1081, "Arambag", 34 },
                    { 1082, "Jhargra", 34 },
                    { 1083, "Sur", 34 },
                    { 1084, "Gangarampu", 34 },
                    { 1085, "Tarakeswa", 34 },
                    { 1086, "Paschim Punropar", 34 },
                    { 1087, "Sonamukh", 34 },
                    { 1088, "PandUrban Agglomeratio", 34 },
                    { 1089, "Mainagur", 34 },
                    { 1090, "Mald", 34 },
                    { 1091, "Panchl", 34 },
                    { 1092, "Raghunathpu", 34 },
                    { 1093, "Kalimpon", 34 },
                    { 1094, "Rampurha", 34 },
                    { 1095, "Tak", 34 },
                    { 1096, "Sainthi", 34 },
                    { 1097, "Murshidaba", 34 },
                    { 1098, "Mema", 34 },
                    { 1100, "Achhnera", 32 },
                    { 1101, "Agra", 32 },
                    { 1102, "Aligarh", 32 },
                    { 1103, "Allahabad", 32 },
                    { 1104, "Amroha", 32 },
                    { 1105, "Azamgarh", 32 },
                    { 1106, "Bahraich", 32 },
                    { 1107, "Chandausi", 32 },
                    { 1108, "Etawah", 32 },
                    { 1109, "Fatehpur Sikri", 32 },
                    { 1110, "Firozabad", 32 },
                    { 1111, "Hapur", 32 },
                    { 1112, "Hardoi ", 32 },
                    { 1113, "Jhansi", 32 },
                    { 1114, "Kalpi", 32 },
                    { 1115, "Kanpur", 32 },
                    { 1116, "Khair", 32 },
                    { 1117, "Laharpur", 32 },
                    { 1118, "Lakhimpur", 32 },
                    { 1119, "Lal Gopalganj Nindaura", 32 },
                    { 1120, "Lalganj", 32 },
                    { 1121, "Lalitpur", 32 },
                    { 1122, "Lar", 32 },
                    { 1123, "Loni", 32 },
                    { 1124, "Lucknow", 32 },
                    { 1125, "Mathura", 32 },
                    { 1126, "Meerut", 32 },
                    { 1127, "Modinagar", 32 },
                    { 1128, "Moradabad", 32 },
                    { 1129, "Nagina", 32 },
                    { 1130, "Najibabad", 32 },
                    { 1131, "Nakur", 32 },
                    { 1132, "Nanpara", 32 },
                    { 1133, "Naraura", 32 },
                    { 1134, "Naugawan Sadat", 32 },
                    { 1135, "Nautanwa", 32 },
                    { 1136, "Nawabganj", 32 },
                    { 1137, "Nehtaur", 32 },
                    { 1138, "Niwai", 32 },
                    { 1139, "Noida", 32 },
                    { 1140, "Noorpur", 32 },
                    { 1141, "Obra", 32 },
                    { 1142, "Orai", 32 },
                    { 1143, "Padrauna", 32 },
                    { 1144, "Palia Kalan", 32 },
                    { 1145, "Parasi", 32 },
                    { 1146, "Phulpur", 32 },
                    { 1147, "Pihani", 32 },
                    { 1148, "Pilibhit", 32 },
                    { 1149, "Pilkhuwa", 32 },
                    { 1150, "Powayan", 32 },
                    { 1151, "Pukhrayan", 32 },
                    { 1152, "Puranpur", 32 },
                    { 1153, "PurqUrban Agglomerationzi", 32 },
                    { 1154, "Purwa", 32 },
                    { 1155, "Rae Bareli", 32 },
                    { 1156, "Rampur", 32 },
                    { 1157, "Rampur Maniharan", 32 },
                    { 1158, "Rasra", 32 },
                    { 1159, "Rath", 32 },
                    { 1160, "Renukoot", 32 },
                    { 1161, "Reoti", 32 },
                    { 1162, "Robertsganj", 32 },
                    { 1163, "Rudauli", 32 },
                    { 1164, "Rudrapur", 32 },
                    { 1165, "Sadabad", 32 },
                    { 1166, "Safipur", 32 },
                    { 1167, "Saharanpur", 32 },
                    { 1168, "Sahaspur", 32 },
                    { 1169, "Sahaswan", 32 },
                    { 1170, "Sahawar", 32 },
                    { 1171, "Sahjanwa", 32 },
                    { 1172, "Saidpur", 32 },
                    { 1173, "Sambhal", 32 },
                    { 1174, "Samdhan", 32 },
                    { 1175, "Samthar", 32 },
                    { 1176, "Sandi", 32 },
                    { 1177, "Sandila", 32 },
                    { 1178, "Sardhana", 32 },
                    { 1179, "Seohara", 32 },
                    { 1180, "Shahabad, Hardoi", 32 },
                    { 1181, "Shahabad, Rampur", 32 },
                    { 1182, "Shahganj", 32 },
                    { 1183, "Shahjahanpur", 32 },
                    { 1184, "Shamli", 32 },
                    { 1185, "Shamsabad, Agra", 32 },
                    { 1186, "Shamsabad, Farrukhabad", 32 },
                    { 1187, "Sherkot", 32 },
                    { 1188, "Shikarpur, Bulandshahr", 32 },
                    { 1189, "Shikohabad", 32 },
                    { 1190, "Shishgarh", 32 },
                    { 1191, "Siana", 32 },
                    { 1192, "Sikanderpur", 32 },
                    { 1193, "Sikandra Rao", 32 },
                    { 1194, "Sikandrabad", 32 },
                    { 1195, "Sirsaganj", 32 },
                    { 1196, "Sirsi", 32 },
                    { 1197, "Sitapur", 32 },
                    { 1198, "Soron", 32 },
                    { 1199, "Sultanpur", 32 },
                    { 1200, "Sumerpur", 32 },
                    { 1201, "SUrban Agglomerationr", 32 },
                    { 1202, "Tanda", 32 },
                    { 1203, "Thakurdwara", 32 },
                    { 1204, "Thana Bhawan", 32 },
                    { 1205, "Tilhar", 32 },
                    { 1206, "Tirwaganj", 32 },
                    { 1207, "Tulsipur", 32 },
                    { 1208, "Tundla", 32 },
                    { 1209, "Ujhani", 32 },
                    { 1210, "Unnao", 32 },
                    { 1211, "Utraula", 32 },
                    { 1212, "Varanasi", 32 },
                    { 1213, "Vrindavan", 32 },
                    { 1214, "Warhapur", 32 },
                    { 1215, "Zaidpur", 32 },
                    { 1216, "Zamania", 32 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_CityId",
                table: "Address",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_CountryId",
                table: "Address",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_StateId",
                table: "Address",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_Applications_CourseId",
                table: "Applications",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Applications_StatusId",
                table: "Applications",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AppUser",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AppUser",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Batchs_CourseId",
                table: "Batchs",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Batchs_TrainerId",
                table: "Batchs",
                column: "TrainerId");

            migrationBuilder.CreateIndex(
                name: "IX_BatchStudents_BatchId",
                table: "BatchStudents",
                column: "BatchId");

            migrationBuilder.CreateIndex(
                name: "IX_BatchStudents_StudentId",
                table: "BatchStudents",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_StateId",
                table: "Cities",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_CodeHelpers_SubjectId",
                table: "CodeHelpers",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Fees_BatchStudentId",
                table: "Fees",
                column: "BatchStudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Fees_StudentId",
                table: "Fees",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_SubjectId",
                table: "Questions",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_States_CountryId",
                table: "States",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_AddressUniqueId",
                table: "Students",
                column: "AddressUniqueId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_CourseOfInterestId",
                table: "Students",
                column: "CourseOfInterestId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Applications");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CodeHelpers");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "EducationBoardsMaster");

            migrationBuilder.DropTable(
                name: "Enquiry");

            migrationBuilder.DropTable(
                name: "Fees");

            migrationBuilder.DropTable(
                name: "Qualification");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "ApplicationStatus");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AppUser");

            migrationBuilder.DropTable(
                name: "BatchStudents");

            migrationBuilder.DropTable(
                name: "Subject");

            migrationBuilder.DropTable(
                name: "Batchs");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "States");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
