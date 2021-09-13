using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace API.Entities
{
    public class AppUser : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        //Relationship one to many === AppUser to Blogs
        public ICollection<Blog> Blogs { get; set; }
        public ICollection<AppUserRole> UserRoles { get; set; }
    }
}
