using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence_CampFinalProject.Migrations
{
    public partial class mig_4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingListItems_ShoppingLists_ShoppingListId",
                table: "ShoppingListItems");

            migrationBuilder.RenameColumn(
                name: "ShoppingListId",
                table: "ShoppingListItems",
                newName: "ItemId");

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingListItems_ShoppingListId",
                table: "ShoppingListItems",
                newName: "IX_ShoppingListItems_ItemId");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "ShoppingLists",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "ItemId",
                table: "ShoppingLists",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingListItems_ShoppingLists_ItemId",
                table: "ShoppingListItems",
                column: "ItemId",
                principalTable: "ShoppingLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingListItems_ShoppingLists_ItemId",
                table: "ShoppingListItems");

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "ShoppingLists");

            migrationBuilder.RenameColumn(
                name: "ItemId",
                table: "ShoppingListItems",
                newName: "ShoppingListId");

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingListItems_ItemId",
                table: "ShoppingListItems",
                newName: "IX_ShoppingListItems_ShoppingListId");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "ShoppingLists",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingListItems_ShoppingLists_ShoppingListId",
                table: "ShoppingListItems",
                column: "ShoppingListId",
                principalTable: "ShoppingLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
