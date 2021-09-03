using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API.Entities
{
    public class AppUser
    {
        [Key]
        public int Id { get; set; }

        public string UserName { get; set; }

        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }

        //Relationship one to many === AppUser to Blogs
        public ICollection<Blog> Blogs { get; set; }
    }
}
