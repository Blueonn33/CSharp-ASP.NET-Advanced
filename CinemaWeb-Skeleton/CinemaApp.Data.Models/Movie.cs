using CinemaApp.Data.Common.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static CinemaApp.Data.Common.EntityValidation.Movie;

namespace CinemaApp.Data.Models
{
    public class Movie : ISoftDeletableEntity
    {
        [Key]
        public Guid Id
        {
            get; set;
        }

        [Required]
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(GenreMaxLength)]
        public string Genre { get; set; } = null!;

        [Column(TypeName = ReleaseDateColumnType)]
        public DateTime ReleaseDate
        {
            get; set;
        }

        [Required]
        [MaxLength(DirectorMaxLength)]
        public string Director { get; set; } = null!;

        public int Duration
        {
            get; set;
        }

        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; } = null!;

        [MaxLength(ImageUrlMaxLength)]
        public string? ImageUrl
        {
            get; set;
        }

        public bool IsDeleted
        {
            get; set;
        }
    }
}
