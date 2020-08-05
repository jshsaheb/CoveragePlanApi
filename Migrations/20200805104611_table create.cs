using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CoveragePlanApi.Migrations
{
    public partial class tablecreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contracts",
                columns: table => new
                {
                    customerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    customerName = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    customerAddress = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    customerGender = table.Column<string>(type: "nvarchar(1)", nullable: true),
                    customerCountry = table.Column<string>(type: "nvarchar(3)", nullable: true),
                    customerDateofBirth = table.Column<string>(type: "nvarchar(3)", nullable: true),
                    saleDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    coveragePlan = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    netPrice = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contracts", x => x.customerId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contracts");
        }
    }
}
