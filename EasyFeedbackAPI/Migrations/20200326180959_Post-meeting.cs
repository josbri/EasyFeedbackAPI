using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyFeedbackAPI.Migrations
{
    public partial class Postmeeting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WaiterID",
                table: "Servicios",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Autor",
                table: "Comments",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Servicios_WaiterID",
                table: "Servicios",
                column: "WaiterID");

            migrationBuilder.AddForeignKey(
                name: "FK_Servicios_Waiters_WaiterID",
                table: "Servicios",
                column: "WaiterID",
                principalTable: "Waiters",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Servicios_Waiters_WaiterID",
                table: "Servicios");

            migrationBuilder.DropIndex(
                name: "IX_Servicios_WaiterID",
                table: "Servicios");

            migrationBuilder.DropColumn(
                name: "WaiterID",
                table: "Servicios");

            migrationBuilder.DropColumn(
                name: "Autor",
                table: "Comments");
        }
    }
}
