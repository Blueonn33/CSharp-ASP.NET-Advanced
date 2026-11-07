using CinemaApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaApp.Data.Configuration
{
    public class UserMovieConfiguration : IEntityTypeConfiguration<UserMovie>
    {
        public void Configure(EntityTypeBuilder<UserMovie> builder)
        {
            // Low performance solutions: applies overhead due to fetching Movie.IsDeleted on each request
            builder.HasQueryFilter(um => um.Movie.IsDeleted == false);
        }
    }
}
