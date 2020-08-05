using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CoveragePlanApi.Migrations
{
    public partial class datemodify : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "customerDateofBirth",
                table: "Contracts",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(3)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "customerDateofBirth",
                table: "Contracts",
                type: "nvarchar(3)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime");
        }
    }
}
