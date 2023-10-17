using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BackendSchedule.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Professional",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Password = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Phone = table.Column<string>(type: "varchar(11)", maxLength: 11, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professional", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Scheduling",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ProfessionalId = table.Column<int>(type: "int", nullable: false),
                    TimePeriods_StartMorning = table.Column<TimeSpan>(type: "time(6)", nullable: true),
                    TimePeriods_EndMorning = table.Column<TimeSpan>(type: "time(6)", nullable: true),
                    TimePeriods_StartAfternoon = table.Column<TimeSpan>(type: "time(6)", nullable: true),
                    TimePeriods_EndAfternoon = table.Column<TimeSpan>(type: "time(6)", nullable: true),
                    TimePeriods_StartNight = table.Column<TimeSpan>(type: "time(6)", nullable: true),
                    TimePeriods_EndNight = table.Column<TimeSpan>(type: "time(6)", nullable: true),
                    WorkDay = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Day = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scheduling", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Scheduling_Professional_ProfessionalId",
                        column: x => x.ProfessionalId,
                        principalTable: "Professional",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Work",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProfessionalId = table.Column<int>(type: "int", nullable: false),
                    Duration = table.Column<TimeSpan>(type: "time(6)", nullable: false),
                    Price = table.Column<double>(type: "double", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Work", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Work_Professional_ProfessionalId",
                        column: x => x.ProfessionalId,
                        principalTable: "Professional",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Appointment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SchedulingId = table.Column<int>(type: "int", nullable: false),
                    WorkId = table.Column<int>(type: "int", nullable: false),
                    CustomerName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CustomerEmail = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CustomerPhone = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    StartTime = table.Column<TimeSpan>(type: "time(6)", nullable: false),
                    EndTime = table.Column<TimeSpan>(type: "time(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appointment_Scheduling_SchedulingId",
                        column: x => x.SchedulingId,
                        principalTable: "Scheduling",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appointment_Work_WorkId",
                        column: x => x.WorkId,
                        principalTable: "Work",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Professional",
                columns: new[] { "Id", "Email", "Name", "Password", "Phone" },
                values: new object[,]
                {
                    { 1, "jhon@gmail.com", "Jhon Carlos", "jhon123", "54996054176" },
                    { 2, "damanga@gmail.com", "Ze Da Manga", "damanga123", "54943022176" },
                    { 3, "batista@gmail.com", "Amado Batista", "batista123", "21948212432" }
                });

            migrationBuilder.InsertData(
                table: "Scheduling",
                columns: new[] { "Id", "Day", "ProfessionalId", "WorkDay" },
                values: new object[] { 1, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, true });

            migrationBuilder.InsertData(
                table: "Work",
                columns: new[] { "Id", "Duration", "Name", "Price", "ProfessionalId" },
                values: new object[,]
                {
                    { 1, new TimeSpan(0, 1, 0, 0, 0), "Corte de Cabelo", 25.0, 1 },
                    { 2, new TimeSpan(0, 1, 30, 0, 0), "Massagem", 50.0, 1 },
                    { 3, new TimeSpan(0, 0, 30, 0, 0), "Manicure", null, 3 }
                });

            migrationBuilder.InsertData(
                table: "Appointment",
                columns: new[] { "Id", "EndTime", "SchedulingId", "StartTime", "WorkId" },
                values: new object[] { 1, new TimeSpan(0, 11, 30, 0, 0), 1, new TimeSpan(0, 10, 30, 0, 0), 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_SchedulingId",
                table: "Appointment",
                column: "SchedulingId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_WorkId",
                table: "Appointment",
                column: "WorkId");

            migrationBuilder.CreateIndex(
                name: "IX_Scheduling_ProfessionalId",
                table: "Scheduling",
                column: "ProfessionalId");

            migrationBuilder.CreateIndex(
                name: "IX_Work_ProfessionalId",
                table: "Work",
                column: "ProfessionalId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointment");

            migrationBuilder.DropTable(
                name: "Scheduling");

            migrationBuilder.DropTable(
                name: "Work");

            migrationBuilder.DropTable(
                name: "Professional");
        }
    }
}
