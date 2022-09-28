using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LevSundt.SqlServerContext.Migrations.Migrations
{
    public partial class RowVersionMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                schema: "bmi",
                table: "Bmi",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RowVersion",
                schema: "bmi",
                table: "Bmi");
        }
    }
}
