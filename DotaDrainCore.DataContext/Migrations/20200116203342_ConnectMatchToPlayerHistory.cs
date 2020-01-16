using Microsoft.EntityFrameworkCore.Migrations;

namespace DotaDrainCore.DataContext.Migrations
{
    public partial class ConnectMatchToPlayerHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayerMatchHistories_Matches_MatchId",
                table: "PlayerMatchHistories");

            migrationBuilder.AlterColumn<int>(
                name: "MatchId",
                table: "PlayerMatchHistories",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerMatchHistories_Matches_MatchId",
                table: "PlayerMatchHistories",
                column: "MatchId",
                principalTable: "Matches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayerMatchHistories_Matches_MatchId",
                table: "PlayerMatchHistories");

            migrationBuilder.AlterColumn<int>(
                name: "MatchId",
                table: "PlayerMatchHistories",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerMatchHistories_Matches_MatchId",
                table: "PlayerMatchHistories",
                column: "MatchId",
                principalTable: "Matches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
