using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyFeedbackAPI.Migrations
{
    public partial class DeletedCommentListFromTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Tables_MesasID",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_MesasID",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "MesasID",
                table: "Comments");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MesasID",
                table: "Comments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_MesasID",
                table: "Comments",
                column: "MesasID");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Tables_MesasID",
                table: "Comments",
                column: "MesasID",
                principalTable: "Tables",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
