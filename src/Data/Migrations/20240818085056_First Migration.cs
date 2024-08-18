using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BqMedicinaApp.API.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Specialties",
                columns: table => new
                {
                    SpeciltyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialties", x => x.SpeciltyId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(60)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Cel = table.Column<string>(type: "nvarchar(11)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Document = table.Column<string>(type: "nvarchar(11)", nullable: false),
                    IsDoctor = table.Column<bool>(type: "bit", nullable: false),
                    IsPatient = table.Column<bool>(type: "bit", nullable: false),
                    IsAttendant = table.Column<bool>(type: "bit", nullable: false),
                    Registration = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    AdmissionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Departament = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Crm = table.Column<string>(type: "nvarchar(15)", nullable: true),
                    SpecialtyId = table.Column<int>(type: "int", nullable: true),
                    MedicalHistory = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    MedicalInsurance = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    MedicalRecord = table.Column<string>(type: "nvarchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Specialties_SpecialtyId",
                        column: x => x.SpecialtyId,
                        principalTable: "Specialties",
                        principalColumn: "SpeciltyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Schedulings",
                columns: table => new
                {
                    SchedulingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    AttendantId = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HourAppointment = table.Column<TimeSpan>(type: "time", nullable: false),
                    DateAppointment = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedulings", x => x.SchedulingId);
                    table.ForeignKey(
                        name: "FK_Schedulings_Users_AttendantId",
                        column: x => x.AttendantId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Schedulings_Users_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Schedulings_Users_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Schedulings_AttendantId",
                table: "Schedulings",
                column: "AttendantId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedulings_DoctorId",
                table: "Schedulings",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedulings_PatientId",
                table: "Schedulings",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_SpecialtyId",
                table: "Users",
                column: "SpecialtyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Schedulings");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Specialties");
        }
    }
}
