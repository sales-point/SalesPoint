using Microsoft.EntityFrameworkCore.Migrations;

namespace SalesPoint.Data.Migrations
{
    public partial class ManyToManyaddedmenusets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuItems_MenuSets_MenuSetId",
                table: "MenuItems");

            migrationBuilder.DropIndex(
                name: "IX_MenuItems_MenuSetId",
                table: "MenuItems");

            migrationBuilder.DropColumn(
                name: "MenuSetId",
                table: "MenuItems");

            migrationBuilder.CreateTable(
                name: "MenuItemMenuSet",
                columns: table => new
                {
                    MenuItemId = table.Column<int>(nullable: false),
                    MenuSetId = table.Column<int>(nullable: false),
                    MenuItemCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItemMenuSet", x => new { x.MenuItemId, x.MenuSetId });
                    table.ForeignKey(
                        name: "FK_MenuItemMenuSet_MenuItems_MenuItemId",
                        column: x => x.MenuItemId,
                        principalTable: "MenuItems",
                        principalColumn: "MenuItemId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MenuItemMenuSet_MenuSets_MenuSetId",
                        column: x => x.MenuSetId,
                        principalTable: "MenuSets",
                        principalColumn: "MenuSetId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MenuItemMenuSet_MenuSetId",
                table: "MenuItemMenuSet",
                column: "MenuSetId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MenuItemMenuSet");

            migrationBuilder.AddColumn<int>(
                name: "MenuSetId",
                table: "MenuItems",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MenuItems_MenuSetId",
                table: "MenuItems",
                column: "MenuSetId");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuItems_MenuSets_MenuSetId",
                table: "MenuItems",
                column: "MenuSetId",
                principalTable: "MenuSets",
                principalColumn: "MenuSetId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
