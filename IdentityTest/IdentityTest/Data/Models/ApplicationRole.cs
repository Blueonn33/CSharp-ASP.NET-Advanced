using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace IdentityTest.Data.Models
{
    public class ApplicationRole : IdentityRole<Guid>
    {
        [Required]
        [DataType(DataType.Text)]
        [MaxLength(100)]
        public required string Label
        {
            get; set;
        }
    }
}
