using Microsoft.EntityFrameworkCore.Migrations;

namespace AspNetCoreShareCar.Data.Migrations
{
    public partial class doubletofloatprice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "Price",
                table: "Travels",
                nullable: false,
                oldClrType: typeof(double));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "Travels",
                nullable: false,
                oldClrType: typeof(float));
        }
    }
}
