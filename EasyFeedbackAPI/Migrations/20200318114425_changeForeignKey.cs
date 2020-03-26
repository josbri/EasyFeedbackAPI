using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyFeedbackAPI.Migrations
{
    public partial class changeForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Waiters_WaiterID",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_WaiterID",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "WaiterID",
                table: "Comments");

            migrationBuilder.AddColumn<int>(
                name: "RestaurantForeignKey",
                table: "Comments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RestaurantID",
                table: "Comments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TableForeignKey",
                table: "Comments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_RestaurantID",
                table: "Comments",
                column: "RestaurantID");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Restaurants_RestaurantID",
                table: "Comments",
                column: "RestaurantID",
                principalTable: "Restaurants",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Restaurants_RestaurantID",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_RestaurantID",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "RestaurantForeignKey",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "RestaurantID",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "TableForeignKey",
                table: "Comments");

            migrationBuilder.AddColumn<int>(
                name: "WaiterID",
                table: "Comments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_WaiterID",
                table: "Comments",
                column: "WaiterID");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Waiters_WaiterID",
                table: "Comments",
                column: "WaiterID",
                principalTable: "Waiters",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
