using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace IdentityTest.Data.Models
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        [PersonalData]
        [DataType(DataType.Text)]
        [MaxLength(200)]
        public string? FullName
        {
            get; set;
        }

        [PersonalData]
        [DataType(DataType.Date)]
        public DateTime? DateOfBirth
        {
            get; set;
        }
    }
}
