using Microsoft.EntityFrameworkCore.Migrations;

namespace CarRentalWebProject.Migrations
{
    public partial class Editdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SelectedCarModel",
                table: "users");

            migrationBuilder.DropColumn(
                name: "SelectedCarName",
                table: "users");

            migrationBuilder.AddColumn<int>(
                name: "CarId",
                table: "users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_users_CarId",
                table: "users",
                column: "CarId");

            migrationBuilder.AddForeignKey(
                name: "FK_users_cars_CarId",
                table: "users",
                column: "CarId",
                principalTable: "cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_users_cars_CarId",
                table: "users");

            migrationBuilder.DropIndex(
                name: "IX_users_CarId",
                table: "users");

            migrationBuilder.DropColumn(
                name: "CarId",
                table: "users");

            migrationBuilder.AddColumn<string>(
                name: "SelectedCarModel",
                table: "users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SelectedCarName",
                table: "users",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
