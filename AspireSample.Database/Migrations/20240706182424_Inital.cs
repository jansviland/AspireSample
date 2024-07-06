using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspireSample.Database.Migrations
{
    /// <inheritdoc />
    public partial class Inital : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Weather",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false).Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TemperatureC = table.Column<int>(type: "int", nullable: false),
                    Summary = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weather", x => x.Id);
                });
            
            migrationBuilder.InsertData(
                table: "Weather",
                columns: new[] { "Date", "TemperatureC", "Summary" },
                values: new object[,]
                {
                    { new DateTime(2024, 7, 6), 25, "Hot" },
                    { new DateTime(2024, 7, 7), 24, "Warm" },
                    { new DateTime(2024, 7, 8), 23, "Cold" },
                    { new DateTime(2024, 7, 9), 22, "Freezing" },
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Weather");
        }
    }
}
