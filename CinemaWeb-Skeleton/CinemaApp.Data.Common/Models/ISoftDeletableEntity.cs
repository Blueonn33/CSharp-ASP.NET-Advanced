namespace CinemaApp.Data.Common.Models
{
    public interface ISoftDeletableEntity
    {
        public bool IsDeleted
        {
            get; set;
        }
    }
}
