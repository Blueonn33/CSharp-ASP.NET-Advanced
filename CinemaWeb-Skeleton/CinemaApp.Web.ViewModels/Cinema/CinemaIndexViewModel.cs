namespace CinemaApp.Web.ViewModels.Cinema
{
    public class CinemaIndexViewModel
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
