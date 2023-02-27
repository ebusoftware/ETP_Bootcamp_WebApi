using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence_CampFinalProject.Migrations
{
    public partial class mig_6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingListItems_ShoppingLists_ItemId",
                table: "ShoppingListItems");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingLists_AspNetUsers_AppUserId",
                table: "ShoppingLists");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingLists_AppUserId",
                table: "ShoppingLists");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingListItems_ItemId",
                table: "ShoppingListItems");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "ShoppingLists");

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "ShoppingListItems");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "ShoppingLists",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingLists_ItemId",
                table: "ShoppingLists",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingLists_UserId",
                table: "ShoppingLists",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingLists_AspNetUsers_UserId",
                table: "ShoppingLists",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingLists_ShoppingListItems_ItemId",
                table: "ShoppingLists",
                column: "ItemId",
                principalTable: "ShoppingListItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingLists_AspNetUsers_UserId",
                table: "ShoppingLists");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingLists_ShoppingListItems_ItemId",
                table: "ShoppingLists");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingLists_ItemId",
                table: "ShoppingLists");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingLists_UserId",
                table: "ShoppingLists");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "ShoppingLists",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "ShoppingLists",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ItemId",
                table: "ShoppingListItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingLists_AppUserId",
                table: "ShoppingLists",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingListItems_ItemId",
                table: "ShoppingListItems",
                column: "ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingListItems_ShoppingLists_ItemId",
                table: "ShoppingListItems",
                column: "ItemId",
                principalTable: "ShoppingLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingLists_AspNetUsers_AppUserId",
                table: "ShoppingLists",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
