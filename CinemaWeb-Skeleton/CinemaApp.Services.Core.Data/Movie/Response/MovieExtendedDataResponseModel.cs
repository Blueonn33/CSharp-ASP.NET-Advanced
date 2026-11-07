namespace CinemaApp.Services.Core.Data.Movie.Response
{
    public class MovieExtendedDataResponseModel
    {
        public Guid Id
        {
            get; set;
        }

        public string Title { get; set; } = null!;

        public string Genre { get; set; } = null!;

        public DateTime ReleaseDate
        {
            get; set;
        }

        public string Director { get; set; } = null!;

        public int Duration
        {
            get; set;
        }

        public string Description { get; set; } = null!;

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
