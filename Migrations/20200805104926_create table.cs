using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CoveragePlanApi.Migrations
{
    public partial class createtable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "coveragePlans",
                columns: table => new
                {
                    coveragePlanId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    coveragePlan = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    EligibilityDateFrom = table.Column<DateTime>(type: "datetime", nullable: false),
                    EligibilityDateTo = table.Column<DateTime>(type: "datetime", nullable: false),
                    EligibilityCountry = table.Column<string>(type: "nvarchar(3)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_coveragePlans", x => x.coveragePlanId);
                });

            migrationBuilder.CreateTable(
                name: "rateCharts",
                columns: table => new
                {
                    rateChartId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    coveragePlan = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    customerGender = table.Column<string>(type: "nvarchar(1)", nullable: true),
                    CustomerAge = table.Column<string>(type: "nvarchar(4)", nullable: true),
                    netPrice = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rateCharts", x => x.rateChartId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "coveragePlans");

            migrationBuilder.DropTable(
                name: "rateCharts");
        }
    }
}
