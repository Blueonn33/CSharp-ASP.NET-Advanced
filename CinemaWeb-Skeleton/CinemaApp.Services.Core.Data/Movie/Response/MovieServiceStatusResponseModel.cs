namespace CinemaApp.Services.Core.Data.Movie.Response
{
    public class MovieServiceStatusResponseModel
    {
        public bool Status
        {
            get; set;
        }
        public IEnumerable<string?> ErrorMessages { get; set; } = new List<string?>();
    }
}
