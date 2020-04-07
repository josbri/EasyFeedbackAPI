using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyFeedbackAPI.Migrations
{
    public partial class restaurantSettings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Restaurants_Settings_SettingsID1",
                table: "Restaurants");

            migrationBuilder.AlterColumn<int>(
                name: "SettingsID1",
                table: "Restaurants",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "SettingsID",
                table: "Restaurants",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurants_Settings_SettingsID1",
                table: "Restaurants",
                column: "SettingsID1",
                principalTable: "Settings",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Restaurants_Settings_SettingsID1",
                table: "Restaurants");

            migrationBuilder.AlterColumn<int>(
                name: "SettingsID1",
                table: "Restaurants",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SettingsID",
                table: "Restaurants",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurants_Settings_SettingsID1",
                table: "Restaurants",
                column: "SettingsID1",
                principalTable: "Settings",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
