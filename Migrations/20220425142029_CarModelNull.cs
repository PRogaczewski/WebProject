using Microsoft.EntityFrameworkCore.Migrations;

namespace CarRentalWebProject.Migrations
{
    public partial class CarModelNull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "cars",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cities", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_cars_CityId",
                table: "cars",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_cars_cities_CityId",
                table: "cars",
                column: "CityId",
                principalTable: "cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cars_cities_CityId",
                table: "cars");

            migrationBuilder.DropTable(
                name: "cities");

            migrationBuilder.DropIndex(
                name: "IX_cars_CityId",
                table: "cars");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "cars");
        }
    }
}
