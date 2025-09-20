using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddColumns_GameMatch_And_Player_v002 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Movements",
                table: "GameMatches");

            migrationBuilder.RenameColumn(
                name: "WinSideX",
                table: "GameMatches",
                newName: "MovementsX");

            migrationBuilder.RenameColumn(
                name: "WinSideO",
                table: "GameMatches",
                newName: "MovementsO");

            migrationBuilder.AddColumn<int>(
                name: "WinnerSide",
                table: "GameMatches",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WinnerSide",
                table: "GameMatches");

            migrationBuilder.RenameColumn(
                name: "MovementsX",
                table: "GameMatches",
                newName: "WinSideX");

            migrationBuilder.RenameColumn(
                name: "MovementsO",
                table: "GameMatches",
                newName: "WinSideO");

            migrationBuilder.AddColumn<int>(
                name: "Movements",
                table: "GameMatches",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
