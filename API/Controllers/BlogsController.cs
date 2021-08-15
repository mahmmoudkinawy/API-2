using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
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
        private readonly IMapper _mapper;

        public BlogsController(IBlogRepository repository, IMapper mapper)
        {
            _repository = repository ??
                throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        [HttpPost]
        public async Task<ActionResult> CreateBlog([FromBody] BlogCreateDto blogCreateDto)
        {
            var blog = _mapper.Map<Blog>(blogCreateDto);

            if (blog == null)
                return BadRequest();

            await _repository.CreateBlogAsync(blog);
            await _repository.SaveChangesAsync();

            return Ok("Created Successfully");
        }
    }
}
