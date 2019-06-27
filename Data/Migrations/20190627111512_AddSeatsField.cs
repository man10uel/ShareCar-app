using Microsoft.EntityFrameworkCore.Migrations;

namespace AspNetCoreShareCar.Data.Migrations
{
    public partial class AddSeatsField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Seats",
                table: "Travels",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Seats",
                table: "Travels");
        }
    }
}
