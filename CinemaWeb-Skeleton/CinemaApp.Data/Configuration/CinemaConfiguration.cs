using CinemaApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaApp.Data.Configuration
{
    public class CinemaConfiguration : IEntityTypeConfiguration<Cinema>
    {
        public static readonly IEnumerable<Cinema> CinemasSeedData = new List<Cinema>()
        {
            new Cinema
            {
                Id = Guid.Parse("4e2bc84e-7882-4386-8a83-17ad369a73b1"),
                Name = "Sofia Cinema Center",
                Location = "123 Vitosha Boulevard, Sofia",
                IsDeleted = false
            },
            new Cinema
            {
                Id = Guid.Parse("087287bc-c953-413d-a967-1d3b4ba9e691"),
                Name = "Plovdiv Grand Cinema",
                Location = "45 Main Street, Plovdiv",
                IsDeleted = false
            },
            new Cinema
            {
                Id = Guid.Parse("8de701c1-d8c5-401a-943c-15404f741b65"),
                Name = "Varna Seaside Cinema",
                Location = "10 Sea Garden Avenue, Varna",
                IsDeleted = false
            }
        };

        public void Configure(EntityTypeBuilder<Cinema> builder)
        {
            builder.HasQueryFilter(c => c.IsDeleted == false);
            builder.HasData(CinemasSeedData);
        }
    }
}
