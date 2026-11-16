using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CinemaApp.Data.Models
{
    [PrimaryKey(nameof(TicketId), nameof(UserId))]
    public class UserTicket
    {
        [Required]
        [ForeignKey(nameof(User))]
        public string UserId { get; set; } = null!;

        public virtual IdentityUser User { get; set; } = null!;

        [ForeignKey(nameof(Ticket))]
        public Guid TicketId
        {
            get; set;
        }

        public virtual Ticket Ticket { get; set; } = null!;

        public int Quantity
        {
            get; set;
        }
    }
}
