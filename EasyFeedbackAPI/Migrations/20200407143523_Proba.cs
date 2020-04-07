using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyFeedbackAPI.Migrations
{
    public partial class Proba : Migration
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
                name: "UserID",
                table: "Servicios",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SettingsID",
                table: "Restaurants",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SettingsID1",
                table: "Restaurants",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Tables",
                table: "Restaurants",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Autor",
                table: "Comments",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LicencesUsed = table.Column<int>(nullable: true),
                    LicensesLeft = table.Column<int>(nullable: true),
                    ReturnCode = table.Column<int>(nullable: false),
                    RestaurantID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CognitoID = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Admin = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "UsersRestaurants",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(nullable: false),
                    RestaurantID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersRestaurants", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UsersRestaurants_Restaurants_RestaurantID",
                        column: x => x.RestaurantID,
                        principalTable: "Restaurants",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsersRestaurants_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Waiters_RestauranteID",
                table: "Waiters",
                column: "RestauranteID");

            migrationBuilder.CreateIndex(
                name: "IX_Servicios_RestaurantID",
                table: "Servicios",
                column: "RestaurantID");

            migrationBuilder.CreateIndex(
                name: "IX_Servicios_UserID",
                table: "Servicios",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Restaurants_SettingsID1",
                table: "Restaurants",
                column: "SettingsID1");

            migrationBuilder.CreateIndex(
                name: "IX_UsersRestaurants_RestaurantID",
                table: "UsersRestaurants",
                column: "RestaurantID");

            migrationBuilder.CreateIndex(
                name: "IX_UsersRestaurants_UserID",
                table: "UsersRestaurants",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurants_Settings_SettingsID1",
                table: "Restaurants",
                column: "SettingsID1",
                principalTable: "Settings",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Servicios_Restaurants_RestaurantID",
                table: "Servicios",
                column: "RestaurantID",
                principalTable: "Restaurants",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Servicios_Users_UserID",
                table: "Servicios",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_Restaurants_Settings_SettingsID1",
                table: "Restaurants");

            migrationBuilder.DropForeignKey(
                name: "FK_Servicios_Restaurants_RestaurantID",
                table: "Servicios");

            migrationBuilder.DropForeignKey(
                name: "FK_Servicios_Users_UserID",
                table: "Servicios");

            migrationBuilder.DropForeignKey(
                name: "FK_Waiters_Restaurants_RestauranteID",
                table: "Waiters");

            migrationBuilder.DropTable(
                name: "Settings");

            migrationBuilder.DropTable(
                name: "UsersRestaurants");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Waiters_RestauranteID",
                table: "Waiters");

            migrationBuilder.DropIndex(
                name: "IX_Servicios_RestaurantID",
                table: "Servicios");

            migrationBuilder.DropIndex(
                name: "IX_Servicios_UserID",
                table: "Servicios");

            migrationBuilder.DropIndex(
                name: "IX_Restaurants_SettingsID1",
                table: "Restaurants");

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
                name: "UserID",
                table: "Servicios");

            migrationBuilder.DropColumn(
                name: "SettingsID",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "SettingsID1",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "Tables",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "Autor",
                table: "Comments");

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
