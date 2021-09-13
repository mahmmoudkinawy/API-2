using System.Collections.Generic;

namespace API.DTOs
{
    public class MemberDto
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public ICollection<BlogDto> Blogs { get; set; }
    }
}
