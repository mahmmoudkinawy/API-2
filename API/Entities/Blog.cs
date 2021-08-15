using System.ComponentModel.DataAnnotations;

namespace API.Entities
{
    public class Blog
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(5, ErrorMessage ="Must be between 5-50")]
        [MaxLength(50, ErrorMessage = "Must be between 5-50")]
        public string Title { get; set; }

        [Required]
        [MinLength(30, ErrorMessage = "Must be between 30-5000")]
        [MaxLength(5000, ErrorMessage = "Must be between 30-5000")]
        public string Content { get; set; }

        [Required]
        [MinLength(10, ErrorMessage = "Must be between 10-90")]
        [MaxLength(90, ErrorMessage = "Must be between 10-90")]
        public string Summary { get; set; }
    }
}
