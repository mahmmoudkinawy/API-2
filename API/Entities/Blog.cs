using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    [Table("Tables")]
    public class Blog
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Summary { get; set; }

        //Fully relationship
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
