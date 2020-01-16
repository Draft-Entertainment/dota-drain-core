using Microsoft.EntityFrameworkCore.Migrations;

namespace DotaDrainCore.DataContext.Migrations
{
    public partial class ItemHistoryManyToMantFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_PlayerMatchHistories_PlayerMatchHistoryId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_PlayerMatchHistoryId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "PlayerMatchHistoryId",
                table: "Items");

            migrationBuilder.AddColumn<int>(
                name: "ItemId",
                table: "PlayerMatchHistories",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ItemPlayerMatchHistories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemId = table.Column<int>(nullable: false),
                    PlayerMatchHistoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemPlayerMatchHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemPlayerMatchHistories_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemPlayerMatchHistories_PlayerMatchHistories_PlayerMatchHistoryId",
                        column: x => x.PlayerMatchHistoryId,
                        principalTable: "PlayerMatchHistories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlayerMatchHistories_ItemId",
                table: "PlayerMatchHistories",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemPlayerMatchHistories_ItemId",
                table: "ItemPlayerMatchHistories",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemPlayerMatchHistories_PlayerMatchHistoryId",
                table: "ItemPlayerMatchHistories",
                column: "PlayerMatchHistoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerMatchHistories_Items_ItemId",
                table: "PlayerMatchHistories",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayerMatchHistories_Items_ItemId",
                table: "PlayerMatchHistories");

            migrationBuilder.DropTable(
                name: "ItemPlayerMatchHistories");

            migrationBuilder.DropIndex(
                name: "IX_PlayerMatchHistories_ItemId",
                table: "PlayerMatchHistories");

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "PlayerMatchHistories");

            migrationBuilder.AddColumn<int>(
                name: "PlayerMatchHistoryId",
                table: "Items",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Items_PlayerMatchHistoryId",
                table: "Items",
                column: "PlayerMatchHistoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_PlayerMatchHistories_PlayerMatchHistoryId",
                table: "Items",
                column: "PlayerMatchHistoryId",
                principalTable: "PlayerMatchHistories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
