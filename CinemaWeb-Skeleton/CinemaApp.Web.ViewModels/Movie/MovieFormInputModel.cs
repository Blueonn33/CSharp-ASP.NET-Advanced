using System.ComponentModel.DataAnnotations;
using static CinemaApp.GCommon.InputValidationConstants.Movie;

namespace CinemaApp.Web.ViewModels.Movie
{
    public class MovieFormInputModel
    {
        public MovieFormInputModel()
        {
            this.ReleaseDate = DateTime.UtcNow.ToString(ReleaseDateFormat);
        }

        [Required(ErrorMessage = TitleRequiredMessage)]
        [MinLength(TitleMinLength, ErrorMessage = TitleMinLengthMessage)]
        [MaxLength(TitleMaxLength, ErrorMessage = TitleMaxLengthMessage)]
        public string Title { get; set; } = null!;

        [Required(ErrorMessage = GenreRequiredMessage)]
        [MinLength(GenreMinLength, ErrorMessage = GenreMinLengthMessage)]
        [MaxLength(GenreMaxLength, ErrorMessage = GenreMaxLengthMessage)]
        public string Genre { get; set; } = null!;

        [Required(ErrorMessage = ReleaseDateRequiredMessage)]
        public string ReleaseDate
        {
            get; set;
        }

        [Required(ErrorMessage = DurationRequiredMessage)]
        [Range(DurationMin, DurationMax, ErrorMessage = DurationRangeMessage)]
        public int Duration
        {
            get; set;
        }

        [Required(ErrorMessage = DirectorRequiredMessage)]
        [MinLength(DirectorNameMinLength, ErrorMessage = DirectorNameMinLengthMessage)]
        [MaxLength(DirectorNameMaxLength, ErrorMessage = DirectorNameMaxLengthMessage)]
        public string Director { get; set; } = null!;

        [Required(ErrorMessage = DescriptionRequiredMessage)]
        [MinLength(DescriptionMinLength, ErrorMessage = DescriptionMinLengthMessage)]
        [MaxLength(DescriptionMaxLength, ErrorMessage = DescriptionMaxLengthMessage)]
        public string Description { get; set; } = null!;

        [MaxLength(ImageUrlMaxLength, ErrorMessage = ImageUrlMaxLengthMessage)]
        public string? ImageUrl
        {
            get; set;
        }
    }
}
