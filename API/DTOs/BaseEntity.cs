using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class BaseEntity
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
