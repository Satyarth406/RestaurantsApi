using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RestaurantsDataAccessLayer.Migrations
{
    public partial class addedlocationdifferently : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Restaurants_Address_LocationID",
                table: "Restaurants");

            migrationBuilder.DropIndex(
                name: "IX_Restaurants_LocationID",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "LocationID",
                table: "Restaurants");

            migrationBuilder.AlterColumn<string>(
                name: "State",
                table: "Address",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Line1",
                table: "Address",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Country",
                table: "Address",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Address",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RestaurantID",
                table: "Address",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Address_RestaurantID",
                table: "Address",
                column: "RestaurantID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Restaurants_RestaurantID",
                table: "Address",
                column: "RestaurantID",
                principalTable: "Restaurants",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_Restaurants_RestaurantID",
                table: "Address");

            migrationBuilder.DropIndex(
                name: "IX_Address_RestaurantID",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "RestaurantID",
                table: "Address");

            migrationBuilder.AddColumn<Guid>(
                name: "LocationID",
                table: "Restaurants",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "State",
                table: "Address",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Line1",
                table: "Address",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Country",
                table: "Address",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Address",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100);

            migrationBuilder.CreateIndex(
                name: "IX_Restaurants_LocationID",
                table: "Restaurants",
                column: "LocationID");

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurants_Address_LocationID",
                table: "Restaurants",
                column: "LocationID",
                principalTable: "Address",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
