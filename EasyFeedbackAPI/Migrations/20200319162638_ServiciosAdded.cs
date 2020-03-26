using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyFeedbackAPI.Migrations
{
    public partial class ServiciosAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Restaurants_RestaurantID",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Tables_TableID",
                table: "Comments");

            migrationBuilder.DropTable(
                name: "Chefs");

            migrationBuilder.DropIndex(
                name: "IX_Comments_RestaurantID",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_TableID",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "RestaurantID",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "TableID",
                table: "Comments");

            migrationBuilder.AddColumn<string>(
                name: "Logo",
                table: "Restaurants",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MesasID",
                table: "Comments",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ServicioID",
                table: "Comments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Servicios",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(nullable: false),
                    MesaID = table.Column<int>(nullable: false),
                    Comensales = table.Column<int>(nullable: false),
                    AverageFood = table.Column<double>(nullable: false),
                    AverageService = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicios", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Servicios_Tables_MesaID",
                        column: x => x.MesaID,
                        principalTable: "Tables",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_MesasID",
                table: "Comments",
                column: "MesasID");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ServicioID",
                table: "Comments",
                column: "ServicioID");

            migrationBuilder.CreateIndex(
                name: "IX_Servicios_MesaID",
                table: "Servicios",
                column: "MesaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Tables_MesasID",
                table: "Comments",
                column: "MesasID",
                principalTable: "Tables",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Servicios_ServicioID",
                table: "Comments",
                column: "ServicioID",
                principalTable: "Servicios",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Tables_MesasID",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Servicios_ServicioID",
                table: "Comments");

            migrationBuilder.DropTable(
                name: "Servicios");

            migrationBuilder.DropIndex(
                name: "IX_Comments_MesasID",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_ServicioID",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "Logo",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "MesasID",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "ServicioID",
                table: "Comments");

            migrationBuilder.AddColumn<int>(
                name: "RestaurantID",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TableID",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Chefs",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chefs", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_RestaurantID",
                table: "Comments",
                column: "RestaurantID");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_TableID",
                table: "Comments",
                column: "TableID");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Restaurants_RestaurantID",
                table: "Comments",
                column: "RestaurantID",
                principalTable: "Restaurants",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Tables_TableID",
                table: "Comments",
                column: "TableID",
                principalTable: "Tables",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
