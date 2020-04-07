using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyFeedbackAPI.Migrations
{
    public partial class restaurantSettings3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersRestaurants_Users_UserID1",
                table: "UsersRestaurants");

            migrationBuilder.DropIndex(
                name: "IX_UsersRestaurants_UserID1",
                table: "UsersRestaurants");

            migrationBuilder.DropColumn(
                name: "UserID1",
                table: "UsersRestaurants");

            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "UsersRestaurants",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UsersRestaurants_UserID",
                table: "UsersRestaurants",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_UsersRestaurants_Users_UserID",
                table: "UsersRestaurants",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersRestaurants_Users_UserID",
                table: "UsersRestaurants");

            migrationBuilder.DropIndex(
                name: "IX_UsersRestaurants_UserID",
                table: "UsersRestaurants");

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "UsersRestaurants",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "UserID1",
                table: "UsersRestaurants",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UsersRestaurants_UserID1",
                table: "UsersRestaurants",
                column: "UserID1");

            migrationBuilder.AddForeignKey(
                name: "FK_UsersRestaurants_Users_UserID1",
                table: "UsersRestaurants",
                column: "UserID1",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
