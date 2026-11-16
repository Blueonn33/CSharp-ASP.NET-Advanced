using CinemaApp.Data.Common.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static CinemaApp.Data.Common.EntityValidation.CinemaMovie;

namespace CinemaApp.Data.Models
{
    public class CinemaMovie : ISoftDeletableEntity
    {
        [Key]
        public Guid Id
        {
            get; set;
        }

        [ForeignKey(nameof(Movie))]
        public Guid MovieId
        {
            get; set;
        }

        public virtual Movie Movie { get; set; } = null!;

        [ForeignKey(nameof(Cinema))]
        public Guid CinemaId
        {
            get; set;
        }

        public virtual Cinema Cinema { get; set; } = null!;

        public int AvailableTickets
        {
            get; set;
        }

        public decimal TicketPrice
        {
            get; set;
        }

        [Column(TypeName = ShowtimeColumnType)]
        public DateTime Showtime
        {
            get; set;
        }

        public bool IsDeleted
        {
            get; set;
        }

        public virtual ICollection<CinemaMovie> MovieProjections { get; set; } = new HashSet<CinemaMovie>();

        public virtual ICollection<Ticket> Tickets { get; set; } = new HashSet<Ticket>();
    }
}
