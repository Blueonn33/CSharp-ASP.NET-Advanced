using CinemaApp.Data.Models;
using Microsoft.AspNetCore.Identity;

namespace CinemaApp.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    public class ApplicationDbContext : IdentityDbContext<IdentityUser, IdentityRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Movie> Movies { get; set; } = null!;
        public virtual DbSet<UserMovie> UsersMovies { get; set; } = null!;
        public virtual DbSet<Cinema> Cinemas { get; set; } = null!;
        public virtual DbSet<CinemaMovie> Projections { get; set; } = null!;
        public virtual DbSet<Ticket> Tickets { get; set; } = null!;
        public virtual DbSet<UserTicket> UsersTickets { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}
