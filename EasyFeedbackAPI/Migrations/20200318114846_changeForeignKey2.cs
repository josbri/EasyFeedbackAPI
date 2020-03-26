using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyFeedbackAPI.Migrations
{
    public partial class changeForeignKey2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Tables_TableID",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "RestaurantForeignKey",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "TableForeignKey",
                table: "Comments");

            migrationBuilder.AlterColumn<int>(
                name: "TableID",
                table: "Comments",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Tables_TableID",
                table: "Comments",
                column: "TableID",
                principalTable: "Tables",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Tables_TableID",
                table: "Comments");

            migrationBuilder.AlterColumn<int>(
                name: "TableID",
                table: "Comments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "RestaurantForeignKey",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TableForeignKey",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Tables_TableID",
                table: "Comments",
                column: "TableID",
                principalTable: "Tables",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
