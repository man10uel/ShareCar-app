using Microsoft.EntityFrameworkCore.Migrations;

namespace AspNetCoreShareCar.Data.Migrations
{
    public partial class AddPaidField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddColumn<bool>(
                name: "Paid",
                table: "Travels",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Paid",
                table: "Travels");
                          
        }
    }
}
