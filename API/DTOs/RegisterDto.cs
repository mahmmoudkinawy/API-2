using System.ComponentModel.DataAnnotations;

namespace API.DTOs.Users
{
    public class RegisterDto : BaseEntity
    {
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
    }
}
