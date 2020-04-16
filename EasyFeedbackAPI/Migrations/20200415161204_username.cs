using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyFeedbackAPI.Migrations
{
    public partial class username : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Abrev",
                table: "Restaurants",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "ID", "Admin", "CognitoID", "Email", "Name", "Surname", "Username" },
                values: new object[] { 1, true, "90df7e3b-5d67-4d86-a428-3392fc6638f8", "mira@mira.com", "Josep", "Mira", "mira" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "Username",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Abrev",
                table: "Restaurants");
        }
    }
}
