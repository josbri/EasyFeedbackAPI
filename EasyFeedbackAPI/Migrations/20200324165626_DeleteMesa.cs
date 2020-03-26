using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyFeedbackAPI.Migrations
{
    public partial class DeleteMesa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Servicios_Tables_MesaID",
                table: "Servicios");

            migrationBuilder.DropIndex(
                name: "IX_Servicios_MesaID",
                table: "Servicios");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Servicios_MesaID",
                table: "Servicios",
                column: "MesaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Servicios_Tables_MesaID",
                table: "Servicios",
                column: "MesaID",
                principalTable: "Tables",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
