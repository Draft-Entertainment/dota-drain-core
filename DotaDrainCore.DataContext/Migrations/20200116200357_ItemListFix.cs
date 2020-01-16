using Microsoft.EntityFrameworkCore.Migrations;

namespace DotaDrainCore.DataContext.Migrations
{
    public partial class ItemListFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayerMatchHistories_Items_ItemId",
                table: "PlayerMatchHistories");

            migrationBuilder.DropIndex(
                name: "IX_PlayerMatchHistories_ItemId",
                table: "PlayerMatchHistories");

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "PlayerMatchHistories");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ItemId",
                table: "PlayerMatchHistories",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PlayerMatchHistories_ItemId",
                table: "PlayerMatchHistories",
                column: "ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerMatchHistories_Items_ItemId",
                table: "PlayerMatchHistories",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
