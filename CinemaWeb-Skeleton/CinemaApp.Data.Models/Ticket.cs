using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static CinemaApp.Data.Common.EntityValidation.Ticket;

namespace CinemaApp.Data.Models
{
    public class Ticket
    {
        [Key]
        public Guid Id
        {
            get; set;
        }

        [Column(TypeName = PriceColumnType)]
        public decimal Price
        {
            get; set;
        }

        [ForeignKey(nameof(Projection))]
        public Guid ProjectionId
        {
            get; set;
        }

        public virtual CinemaMovie Projection { get; set; } = null!;
        public virtual ICollection<UserTicket> TicketUsers { get; set; } = new List<UserTicket>();
    }
}
