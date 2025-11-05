using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlertDengueApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DengueAlerts",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    StartOfEpiWeek = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    EpidemiologicalWeek = table.Column<int>(type: "int", nullable: false),
                    EpidemiologicalYear = table.Column<int>(type: "int", nullable: false),
                    EstimatedCases = table.Column<double>(type: "double", nullable: false),
                    EstimatedCasesMin = table.Column<double>(type: "double", nullable: false),
                    EstimatedCasesMax = table.Column<double>(type: "double", nullable: false),
                    ReportedCases = table.Column<int>(type: "int", nullable: false),
                    ProbabilityRtAbove1 = table.Column<double>(type: "double", nullable: false),
                    IncidencePer100k = table.Column<double>(type: "double", nullable: false),
                    AlertLevel = table.Column<int>(type: "int", nullable: false),
                    ModelVersion = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Rt = table.Column<double>(type: "double", nullable: false),
                    Population = table.Column<double>(type: "double", nullable: false),
                    TempMin = table.Column<double>(type: "double", nullable: false),
                    TempAvg = table.Column<double>(type: "double", nullable: false),
                    TempMax = table.Column<double>(type: "double", nullable: false),
                    HumidityMin = table.Column<double>(type: "double", nullable: false),
                    HumidityAvg = table.Column<double>(type: "double", nullable: false),
                    HumidityMax = table.Column<double>(type: "double", nullable: false),
                    Receptivity = table.Column<int>(type: "int", nullable: false),
                    Transmission = table.Column<int>(type: "int", nullable: false),
                    IncidenceLevel = table.Column<int>(type: "int", nullable: false),
                    AccumulatedNotifications = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DengueAlerts", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_DengueAlerts_EpidemiologicalWeek_EpidemiologicalYear",
                table: "DengueAlerts",
                columns: new[] { "EpidemiologicalWeek", "EpidemiologicalYear" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DengueAlerts");
        }
    }
}
