using API.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Interfaces
{
    public interface IBlogRepository
    {
        Task<IEnumerable<Blog>> GetAllBlogAsync();
        Task<Blog> GetBlogAsync(int id);
        void UpdateBlog(Blog blog);
        Task CreateBlogAsync(Blog blog);
        void DeleteBlog(Blog blog);
        Task<bool> SaveChangesAsync();
    }
}
