using Microsoft.EntityFrameworkCore.Migrations;

namespace CoffeeLamp.Migrations
{
    public partial class AddUsersAndRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Role = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Role);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Login = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Surname = table.Column<string>(nullable: false),
                    RoleFK = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Login);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleFK",
                        column: x => x.RoleFK,
                        principalTable: "Roles",
                        principalColumn: "Role",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleFK",
                table: "Users",
                column: "RoleFK");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
