using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddCinemaMovieMappingEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cinema",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Location = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cinema", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CinemaMovie",
                columns: table => new
                {
                    MovieId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CinemaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AvailableTickets = table.Column<int>(type: "int", nullable: false),
                    Showtime = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CinemaMovieCinemaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CinemaMovieMovieId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CinemaMovie", x => new { x.MovieId, x.CinemaId });
                    table.ForeignKey(
                        name: "FK_CinemaMovie_CinemaMovie_CinemaMovieMovieId_CinemaMovieCinemaId",
                        columns: x => new { x.CinemaMovieMovieId, x.CinemaMovieCinemaId },
                        principalTable: "CinemaMovie",
                        principalColumns: new[] { "MovieId", "CinemaId" });
                    table.ForeignKey(
                        name: "FK_CinemaMovie_Cinema_CinemaId",
                        column: x => x.CinemaId,
                        principalTable: "Cinema",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CinemaMovie_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CinemaMovie_CinemaId",
                table: "CinemaMovie",
                column: "CinemaId");

            migrationBuilder.CreateIndex(
                name: "IX_CinemaMovie_CinemaMovieMovieId_CinemaMovieCinemaId",
                table: "CinemaMovie",
                columns: new[] { "CinemaMovieMovieId", "CinemaMovieCinemaId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CinemaMovie");

            migrationBuilder.DropTable(
                name: "Cinema");
        }
    }
}
