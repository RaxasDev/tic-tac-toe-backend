using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Create_InitialMigration_Player_GameMatch_v001 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Updated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GameMatches",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PlayerXId = table.Column<Guid>(type: "uuid", nullable: false),
                    PlayerOId = table.Column<Guid>(type: "uuid", nullable: false),
                    WinSideX = table.Column<int>(type: "integer", nullable: false),
                    WinSideO = table.Column<int>(type: "integer", nullable: false),
                    Movements = table.Column<int>(type: "integer", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Updated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameMatches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GameMatches_Players_PlayerOId",
                        column: x => x.PlayerOId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GameMatches_Players_PlayerXId",
                        column: x => x.PlayerXId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GameMatches_PlayerOId",
                table: "GameMatches",
                column: "PlayerOId");

            migrationBuilder.CreateIndex(
                name: "IX_GameMatches_PlayerXId",
                table: "GameMatches",
                column: "PlayerXId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameMatches");

            migrationBuilder.DropTable(
                name: "Players");
        }
    }
}
