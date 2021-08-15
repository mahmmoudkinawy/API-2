using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("api/Blogs")]
    public class BlogsController : ControllerBase
    {
        private readonly IBlogRepository _repository;

        public BlogsController(IBlogRepository repository)
        {
            _repository = repository ??
                throw new ArgumentNullException(nameof(repository));
        }

        [HttpPost]
        public async Task<ActionResult> CreateBlog([FromBody] Blog blog)
        {
            if (blog == null)
                return BadRequest();

            await _repository.CreateBlogAsync(blog);
            await _repository.SaveChangesAsync();

            return Ok("Created Successfully");
        }
    }
}
