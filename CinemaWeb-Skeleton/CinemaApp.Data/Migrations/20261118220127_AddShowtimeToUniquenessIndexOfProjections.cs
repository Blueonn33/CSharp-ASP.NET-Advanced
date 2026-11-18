using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddShowtimeToUniquenessIndexOfProjections : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Projections_CinemaId_MovieId",
                table: "Projections");

            migrationBuilder.CreateIndex(
                name: "IX_Projections_CinemaId_MovieId_Showtime",
                table: "Projections",
                columns: new[] { "CinemaId", "MovieId", "Showtime" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Projections_CinemaId_MovieId_Showtime",
                table: "Projections");

            migrationBuilder.CreateIndex(
                name: "IX_Projections_CinemaId_MovieId",
                table: "Projections",
                columns: new[] { "CinemaId", "MovieId" },
                unique: true);
        }
    }
}
