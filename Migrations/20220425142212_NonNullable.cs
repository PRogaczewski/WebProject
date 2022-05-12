using Microsoft.EntityFrameworkCore.Migrations;

namespace CarRentalWebProject.Migrations
{
    public partial class NonNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cars_cities_CityId",
                table: "cars");

            migrationBuilder.AlterColumn<int>(
                name: "CityId",
                table: "cars",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_cars_cities_CityId",
                table: "cars",
                column: "CityId",
                principalTable: "cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cars_cities_CityId",
                table: "cars");

            migrationBuilder.AlterColumn<int>(
                name: "CityId",
                table: "cars",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_cars_cities_CityId",
                table: "cars",
                column: "CityId",
                principalTable: "cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
