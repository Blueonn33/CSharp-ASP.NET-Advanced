using CinemaApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaApp.Data.Configuration
{
    public class CinemaMovieConfiguration : IEntityTypeConfiguration<CinemaMovie>
    {
        public void Configure(EntityTypeBuilder<CinemaMovie> builder)
        {
            builder
                .HasQueryFilter(cm => cm.IsDeleted == false &&
                                      cm.Movie.IsDeleted == false &&
                                      cm.Cinema.IsDeleted == false);

            builder
                .HasIndex(cm => new { cm.CinemaId, cm.MovieId })
                .IsUnique();
        }
    }
}
