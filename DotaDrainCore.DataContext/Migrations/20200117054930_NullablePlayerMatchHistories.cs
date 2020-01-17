using Microsoft.EntityFrameworkCore.Migrations;

namespace DotaDrainCore.DataContext.Migrations
{
    public partial class NullablePlayerMatchHistories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayerMatchHistories_Heroes_HeroId",
                table: "PlayerMatchHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayerMatchHistories_Matches_MatchId",
                table: "PlayerMatchHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayerMatchHistories_Players_PlayerId",
                table: "PlayerMatchHistories");

            migrationBuilder.AlterColumn<int>(
                name: "PlayerId",
                table: "PlayerMatchHistories",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "MatchId",
                table: "PlayerMatchHistories",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "HeroId",
                table: "PlayerMatchHistories",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerMatchHistories_Heroes_HeroId",
                table: "PlayerMatchHistories",
                column: "HeroId",
                principalTable: "Heroes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerMatchHistories_Matches_MatchId",
                table: "PlayerMatchHistories",
                column: "MatchId",
                principalTable: "Matches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerMatchHistories_Players_PlayerId",
                table: "PlayerMatchHistories",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayerMatchHistories_Heroes_HeroId",
                table: "PlayerMatchHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayerMatchHistories_Matches_MatchId",
                table: "PlayerMatchHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayerMatchHistories_Players_PlayerId",
                table: "PlayerMatchHistories");

            migrationBuilder.AlterColumn<int>(
                name: "PlayerId",
                table: "PlayerMatchHistories",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MatchId",
                table: "PlayerMatchHistories",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "HeroId",
                table: "PlayerMatchHistories",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerMatchHistories_Heroes_HeroId",
                table: "PlayerMatchHistories",
                column: "HeroId",
                principalTable: "Heroes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerMatchHistories_Matches_MatchId",
                table: "PlayerMatchHistories",
                column: "MatchId",
                principalTable: "Matches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerMatchHistories_Players_PlayerId",
                table: "PlayerMatchHistories",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
