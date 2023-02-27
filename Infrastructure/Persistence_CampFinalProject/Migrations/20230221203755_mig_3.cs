using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence_CampFinalProject.Migrations
{
    public partial class mig_3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShoppingListShoppingListItem");

            migrationBuilder.AddColumn<int>(
                name: "ShoppingListId",
                table: "ShoppingListItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingListItems_ShoppingListId",
                table: "ShoppingListItems",
                column: "ShoppingListId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingListItems_ShoppingLists_ShoppingListId",
                table: "ShoppingListItems",
                column: "ShoppingListId",
                principalTable: "ShoppingLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingListItems_ShoppingLists_ShoppingListId",
                table: "ShoppingListItems");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingListItems_ShoppingListId",
                table: "ShoppingListItems");

            migrationBuilder.DropColumn(
                name: "ShoppingListId",
                table: "ShoppingListItems");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "ShoppingListShoppingListItem",
                columns: table => new
                {
                    ShoppingListItemsId = table.Column<int>(type: "int", nullable: false),
                    ShoppingListsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingListShoppingListItem", x => new { x.ShoppingListItemsId, x.ShoppingListsId });
                    table.ForeignKey(
                        name: "FK_ShoppingListShoppingListItem_ShoppingListItems_ShoppingListItemsId",
                        column: x => x.ShoppingListItemsId,
                        principalTable: "ShoppingListItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShoppingListShoppingListItem_ShoppingLists_ShoppingListsId",
                        column: x => x.ShoppingListsId,
                        principalTable: "ShoppingLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingListShoppingListItem_ShoppingListsId",
                table: "ShoppingListShoppingListItem",
                column: "ShoppingListsId");
        }
    }
}
