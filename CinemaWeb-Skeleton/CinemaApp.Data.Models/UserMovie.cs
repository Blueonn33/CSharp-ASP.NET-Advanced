using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CinemaApp.Data.Models
{
    [PrimaryKey(nameof(UserId), nameof(MovieId))]
    public class UserMovie
    {
        [Required]
        [ForeignKey(nameof(User))]
        public string UserId { get; set; } = null!;

        public virtual IdentityUser User { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(Movie))]
        public Guid MovieId
        {
            get; set;
        }

        public virtual Movie Movie { get; set; } = null!;
    }
}
