using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace SalesPoint.Data.Migrations
{
    public partial class MenudbsetsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MenuSets",
                columns: table => new
                {
                    MenuSetId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Price = table.Column<decimal>(nullable: false),
                    Description = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuSets", x => x.MenuSetId);
                });

            migrationBuilder.CreateTable(
                name: "MenuTypes",
                columns: table => new
                {
                    MenuTypeId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuTypes", x => x.MenuTypeId);
                });

            migrationBuilder.CreateTable(
                name: "MenuItems",
                columns: table => new
                {
                    MenuItemId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Price = table.Column<decimal>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Weight = table.Column<decimal>(nullable: false),
                    Mixture = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    MenuTypeId = table.Column<int>(nullable: false),
                    MenuSetId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItems", x => x.MenuItemId);
                    table.ForeignKey(
                        name: "FK_MenuItems_MenuSets_MenuSetId",
                        column: x => x.MenuSetId,
                        principalTable: "MenuSets",
                        principalColumn: "MenuSetId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MenuItems_MenuTypes_MenuTypeId",
                        column: x => x.MenuTypeId,
                        principalTable: "MenuTypes",
                        principalColumn: "MenuTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MenuItems_MenuSetId",
                table: "MenuItems",
                column: "MenuSetId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItems_MenuTypeId",
                table: "MenuItems",
                column: "MenuTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MenuItems");

            migrationBuilder.DropTable(
                name: "MenuSets");

            migrationBuilder.DropTable(
                name: "MenuTypes");
        }
    }
}
