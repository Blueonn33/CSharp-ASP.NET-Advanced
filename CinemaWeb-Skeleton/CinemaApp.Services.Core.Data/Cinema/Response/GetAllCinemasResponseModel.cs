namespace CinemaApp.Services.Core.Data.Cinema.Response
{
    public class GetAllCinemasResponseModel
    {
        public Guid Id
        {
            get; set;
        }

        public string Name
        {
            get; set;
        } = null!;

        public string Location
        {
            get; set;
        } = null!;
    }
}
