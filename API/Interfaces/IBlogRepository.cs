using API.Entities;
using System.Threading.Tasks;

namespace API.Interfaces
{
    public interface IBlogRepository
    {
        Task CreateBlogAsync(Blog blog);
        Task<bool> SaveChangesAsync();
    }
}
