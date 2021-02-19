using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FootballShow.Migrations
{
    public partial class initialmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Leagues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmblemUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leagues", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WebSite = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Arena = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LeagueId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teams_Leagues_LeagueId",
                        column: x => x.LeagueId,
                        principalTable: "Leagues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Matches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HomeTeam = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AwayTeam = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HomeTeamGoals = table.Column<int>(type: "int", nullable: false),
                    AwayTeamGoals = table.Column<int>(type: "int", nullable: false),
                    LocalDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TeamWinner = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TeamId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Matches_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Leagues",
                columns: new[] { "Id", "Country", "EmblemUrl", "Name" },
                values: new object[] { 2002, "Germany", "", "Bundesliga" });

            migrationBuilder.InsertData(
                table: "Leagues",
                columns: new[] { "Id", "Country", "EmblemUrl", "Name" },
                values: new object[] { 2021, "England", "", "Premier League" });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "Arena", "LeagueId", "Name", "WebSite" },
                values: new object[,]
                {
                    { 1, "RheinEnergieSTADION", 2002, "1. FC Koln", "http://www.fc-koeln.de" },
                    { 5, "Allianz Arena", 2002, "FC Bayern Munchen", "http://www.fcbayern.de" },
                    { 57, "Emirates Stadium", 2021, "Arsenal FC", "http://www.arsenal.com" },
                    { 61, "Stamford Bridge", 2021, "Chelsea FC", "http://www.chelseafc.com" }
                });

            migrationBuilder.InsertData(
                table: "Matches",
                columns: new[] { "Id", "AwayTeam", "AwayTeamGoals", "HomeTeam", "HomeTeamGoals", "LocalDate", "TeamId", "TeamWinner" },
                values: new object[,]
                {
                    { 1, "1. FC Koln", 0, "Eintracht Frankfurt", 2, new DateTime(2021, 2, 14, 16, 30, 0, 0, DateTimeKind.Local), 1, "Eintracht Frankfurt" },
                    { 2, "Arminia Bielefeld", 3, "FC Bayern München", 3, new DateTime(2021, 2, 15, 21, 30, 0, 0, DateTimeKind.Local), 5, "DRAW" },
                    { 3, "Leeds United FC", 2, "Arsenal FC", 4, new DateTime(2021, 2, 14, 18, 30, 0, 0, DateTimeKind.Local), 57, "Arsenal FC" },
                    { 4, "Newcastle United FC", 0, "Chelsea FC", 2, new DateTime(2021, 2, 15, 22, 0, 0, 0, DateTimeKind.Local), 61, "Chelsea FC" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Matches_TeamId",
                table: "Matches",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_LeagueId",
                table: "Teams",
                column: "LeagueId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Matches");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "Leagues");
        }
    }
}
