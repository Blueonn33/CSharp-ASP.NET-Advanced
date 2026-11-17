using CinemaApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaApp.Data.Configuration
{
    public class CinemaMovieConfiguration : IEntityTypeConfiguration<CinemaMovie>
    {
        // Cinema IDs from CinemaConfiguration
        private const string SofiaCinemaId = "4e2bc84e-7882-4386-8a83-17ad369a73b1";
        private const string PlovdivCinemaId = "087287bc-c953-413d-a967-1d3b4ba9e691";
        private const string VarnaCinemaId = "8de701c1-d8c5-401a-943c-15404f741b65";

        // Movie IDs from MovieEntityTypeConfiguration
        private const string InceptionMovieId = "4571bf2f-dbb3-446c-a92a-07cb77f47ed0";
        private const string GodfatherMovieId = "e673a37c-8ffc-46bf-a66d-18b8078d7c94";
        private const string InterstellarMovieId = "2f22c0dd-f7b9-46c3-a753-0d076dafb489";
        private const string DarkKnightMovieId = "eb13b5e6-b8fd-4e11-99ef-446e9e752558";
        private const string PulpFictionMovieId = "94e73f37-e260-4c6f-930b-8bd65c9c8a11";
        private const string MatrixMovieId = "96fcb0c2-807e-4f7d-a28b-14ba6f9cb9b4";

        public static readonly IEnumerable<CinemaMovie> CinemaMoviesSeedData = new List<CinemaMovie>()
        {
            // Sofia Cinema Center projections
            new CinemaMovie
            {
                Id = Guid.Parse("d1a5c8f3-2b1e-4a7c-9f8d-5e3b1c7a4d9e"),
                MovieId = Guid.Parse("4571bf2f-dbb3-446c-a92a-07cb77f47ed0"), // Inception
                CinemaId = Guid.Parse("4e2bc84e-7882-4386-8a83-17ad369a73b1"), // Sofia Cinema Center
                AvailableTickets = 120,
                TicketPrice = 12.50m,
                Showtime = new DateTime(2025, 1, 15, 19, 30, 0),
                IsDeleted = false
            },
            new CinemaMovie
            {
                Id = Guid.Parse("a2f7e9c1-3d4b-4f6e-8a2c-1b5d9e7c3f8a"),
                MovieId = Guid.Parse("2f22c0dd-f7b9-46c3-a753-0d076dafb489"), // Interstellar
                CinemaId = Guid.Parse("4e2bc84e-7882-4386-8a83-17ad369a73b1"), // Sofia Cinema Center
                AvailableTickets = 100,
                TicketPrice = 13.50m,
                Showtime = new DateTime(2025, 1, 16, 20, 00, 0),
                IsDeleted = false
            },
            new CinemaMovie
            {
                Id = Guid.Parse("c3e8b7a2-5f1d-4e9c-7b6a-8d3c2e9f4a1b"),
                MovieId = Guid.Parse("e673a37c-8ffc-46bf-a66d-18b8078d7c94"), // The Godfather
                CinemaId = Guid.Parse("4e2bc84e-7882-4386-8a83-17ad369a73b1"), // Sofia Cinema Center
                AvailableTickets = 85,
                TicketPrice = 11.50m,
                Showtime = new DateTime(2025, 1, 17, 18, 00, 0),
                IsDeleted = false
            },

            // Plovdiv Grand Cinema projections
            new CinemaMovie
            {
                Id = Guid.Parse("b4d9c6e2-1a8f-4b3e-6c7d-9e2f5a8b1c3d"),
                MovieId = Guid.Parse("eb13b5e6-b8fd-4e11-99ef-446e9e752558"), // The Dark Knight
                CinemaId = Guid.Parse("087287bc-c953-413d-a967-1d3b4ba9e691"), // Plovdiv Grand Cinema
                AvailableTickets = 110,
                TicketPrice = 12.00m,
                Showtime = new DateTime(2025, 1, 15, 20, 30, 0),
                IsDeleted = false
            },
            new CinemaMovie
            {
                Id = Guid.Parse("e5f2a9d1-4c7b-4a8e-9d3f-2e6c8b1a5f7d"),
                MovieId = Guid.Parse("94e73f37-e260-4c6f-930b-8bd65c9c8a11"), // Pulp Fiction
                CinemaId = Guid.Parse("087287bc-c953-413d-a967-1d3b4ba9e691"), // Plovdiv Grand Cinema
                AvailableTickets = 95,
                TicketPrice = 11.00m,
                Showtime = new DateTime(2025, 1, 16, 19, 00, 0),
                IsDeleted = false
            },
            new CinemaMovie
            {
                Id = Guid.Parse("f6a3b8c9-2e5d-4f1a-8c9b-7d4e6f3a2c1e"),
                MovieId = Guid.Parse("96fcb0c2-807e-4f7d-a28b-14ba6f9cb9b4"), // The Matrix
                CinemaId = Guid.Parse("087287bc-c953-413d-a967-1d3b4ba9e691"), // Plovdiv Grand Cinema
                AvailableTickets = 130,
                TicketPrice = 12.50m,
                Showtime = new DateTime(2025, 1, 17, 21, 00, 0),
                IsDeleted = false
            },

            // Varna Seaside Cinema projections
            new CinemaMovie
            {
                Id = Guid.Parse("a7b4c8d5-3f6e-4a7b-9c2d-1e8a5f3b7d9c"),
                MovieId = Guid.Parse("4571bf2f-dbb3-446c-a92a-07cb77f47ed0"), // Inception
                CinemaId = Guid.Parse("8de701c1-d8c5-401a-943c-15404f741b65"), // Varna Seaside Cinema
                AvailableTickets = 140,
                TicketPrice = 13.00m,
                Showtime = new DateTime(2025, 1, 15, 17, 00, 0),
                IsDeleted = false
            },
            new CinemaMovie
            {
                Id = Guid.Parse("b8c5d9e6-4a7f-5b8c-0d3e-2f9a6c4b8e1a"),
                MovieId = Guid.Parse("2f22c0dd-f7b9-46c3-a753-0d076dafb489"), // Interstellar
                CinemaId = Guid.Parse("8de701c1-d8c5-401a-943c-15404f741b65"), // Varna Seaside Cinema
                AvailableTickets = 125,
                TicketPrice = 14.00m,
                Showtime = new DateTime(2025, 1, 16, 18, 30, 0),
                IsDeleted = false
            },
            new CinemaMovie
            {
                Id = Guid.Parse("c9d6e0f7-5b8f-6c9d-1e4f-3a0b7d5c9e2b"),
                MovieId = Guid.Parse("eb13b5e6-b8fd-4e11-99ef-446e9e752558"), // The Dark Knight
                CinemaId = Guid.Parse("8de701c1-d8c5-401a-943c-15404f741b65"), // Varna Seaside Cinema
                AvailableTickets = 100,
                TicketPrice = 12.50m,
                Showtime = new DateTime(2025, 1, 17, 19, 30, 0),
                IsDeleted = false
            }
        };

        public void Configure(EntityTypeBuilder<CinemaMovie> builder)
        {
            builder
                .HasQueryFilter(cm => cm.IsDeleted == false &&
                                      cm.Movie.IsDeleted == false &&
                                      cm.Cinema.IsDeleted == false);

            builder
                .HasIndex(cm => new { cm.CinemaId, cm.MovieId })
                .IsUnique();

            builder.HasData(CinemaMoviesSeedData);
        }
    }
}
