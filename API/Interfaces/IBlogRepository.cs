using API.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Interfaces
{
    public interface IBlogRepository
    {
        Task<IEnumerable<Blog>> GetAllBlogAsync();
        Task<Blog> GetBlogAsync(int id);
        Task CreateBlogAsync(Blog blog);
        Task<bool> SaveChangesAsync();
    }
}
