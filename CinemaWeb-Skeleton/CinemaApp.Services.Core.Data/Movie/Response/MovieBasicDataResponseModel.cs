namespace CinemaApp.Services.Core.Data.Movie.Response
{
    public class MovieBasicDataResponseModel
    {
        public Guid Id
        {
            get; set;
        }

        public string Title { get; set; } = null!;

        public string Genre { get; set; } = null!;

        public string? ImageUrl
        {
            get; set;
        }
    }
}
