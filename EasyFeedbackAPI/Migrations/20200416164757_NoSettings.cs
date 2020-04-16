using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyFeedbackAPI.Migrations
{
    public partial class NoSettings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Restaurants_Settings_SettingsID1",
                table: "Restaurants");

            migrationBuilder.DropIndex(
                name: "IX_Restaurants_SettingsID1",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "SettingsID",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "SettingsID1",
                table: "Restaurants");

            migrationBuilder.AddColumn<int>(
                name: "LicencesUsed",
                table: "Restaurants",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LicensesLeft",
                table: "Restaurants",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReturnCode",
                table: "Restaurants",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LicencesUsed",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "LicensesLeft",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "ReturnCode",
                table: "Restaurants");

            migrationBuilder.AddColumn<int>(
                name: "SettingsID",
                table: "Restaurants",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SettingsID1",
                table: "Restaurants",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Restaurants_SettingsID1",
                table: "Restaurants",
                column: "SettingsID1");

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurants_Settings_SettingsID1",
                table: "Restaurants",
                column: "SettingsID1",
                principalTable: "Settings",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
