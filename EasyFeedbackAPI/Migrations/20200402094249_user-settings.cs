using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyFeedbackAPI.Migrations
{
    public partial class usersettings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RestaurantID = table.Column<int>(nullable: false),
                    PassRetorno = table.Column<int>(nullable: false),
                    LicencesUsed = table.Column<int>(nullable: false),
                    LicensesLeft = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Settings_Restaurants_RestaurantID",
                        column: x => x.RestaurantID,
                        principalTable: "Restaurants",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CognitoID = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    RestaurantID = table.Column<int>(nullable: false),
                    Admin = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.ID);
                    table.ForeignKey(
                        name: "FK_User_Restaurants_RestaurantID",
                        column: x => x.RestaurantID,
                        principalTable: "Restaurants",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Settings_RestaurantID",
                table: "Settings",
                column: "RestaurantID");

            migrationBuilder.CreateIndex(
                name: "IX_User_RestaurantID",
                table: "User",
                column: "RestaurantID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Settings");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
