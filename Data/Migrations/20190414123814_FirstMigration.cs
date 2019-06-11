using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AspNetCoreShareCar.Data.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Travels",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DepartureCity = table.Column<string>(nullable: false),
                    ArrivalCity = table.Column<string>(nullable: false),
                    DueAt = table.Column<DateTimeOffset>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    PassengerId = table.Column<string>(nullable: false),
                    DriverId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Travels", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Travels");
        }
    }
}
