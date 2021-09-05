using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class BlogCreateDto
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public string Summary { get; set; }
    }
}
