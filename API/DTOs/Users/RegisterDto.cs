using System.ComponentModel.DataAnnotations;

namespace API.DTOs.Users
{
    public class RegisterDto : BaseLogin
    {
        [EmailAddress]
        public string Email { get; set; }
    }
}
