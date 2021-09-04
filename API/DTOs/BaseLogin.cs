using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class BaseLogin
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
