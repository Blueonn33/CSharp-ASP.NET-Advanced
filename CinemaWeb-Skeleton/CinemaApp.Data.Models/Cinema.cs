using CinemaApp.Data.Common.Models;
using System.ComponentModel.DataAnnotations;
using static CinemaApp.Data.Common.EntityValidation.Cinema;

namespace CinemaApp.Data.Models
{
    public class Cinema : ISoftDeletableEntity
    {
        [Key]
        public Guid Id
        {
            get; set;
        }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(LocationMaxLength)]
        public string Location { get; set; } = null!;

        public bool IsDeleted
        {
            get; set;
        }
    }
}
