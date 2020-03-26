using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyFeedbackAPI.Migrations
{
    public partial class MesasRemoved : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tables");

            migrationBuilder.AlterColumn<string>(
                name: "Surname",
                table: "Waiters",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RestauranteID",
                table: "Waiters",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RestaurantID",
                table: "Servicios",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RestauranteID",
                table: "Servicios",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Tables",
                table: "Restaurants",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Waiters_RestauranteID",
                table: "Waiters",
                column: "RestauranteID");

            migrationBuilder.CreateIndex(
                name: "IX_Servicios_RestaurantID",
                table: "Servicios",
                column: "RestaurantID");

            migrationBuilder.AddForeignKey(
                name: "FK_Servicios_Restaurants_RestaurantID",
                table: "Servicios",
                column: "RestaurantID",
                principalTable: "Restaurants",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Waiters_Restaurants_RestauranteID",
                table: "Waiters",
                column: "RestauranteID",
                principalTable: "Restaurants",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Servicios_Restaurants_RestaurantID",
                table: "Servicios");

            migrationBuilder.DropForeignKey(
                name: "FK_Waiters_Restaurants_RestauranteID",
                table: "Waiters");

            migrationBuilder.DropIndex(
                name: "IX_Waiters_RestauranteID",
                table: "Waiters");

            migrationBuilder.DropIndex(
                name: "IX_Servicios_RestaurantID",
                table: "Servicios");

            migrationBuilder.DropColumn(
                name: "RestauranteID",
                table: "Waiters");

            migrationBuilder.DropColumn(
                name: "RestaurantID",
                table: "Servicios");

            migrationBuilder.DropColumn(
                name: "RestauranteID",
                table: "Servicios");

            migrationBuilder.DropColumn(
                name: "Tables",
                table: "Restaurants");

            migrationBuilder.AlterColumn<string>(
                name: "Surname",
                table: "Waiters",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.CreateTable(
                name: "Tables",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComensalesNum = table.Column<int>(type: "int", nullable: false),
                    NumMesa = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tables", x => x.ID);
                });
        }
    }
}
