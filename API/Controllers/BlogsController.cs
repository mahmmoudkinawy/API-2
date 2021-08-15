using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BlogDto>>> GetAllBlogs()
        {
            var blogs = await _repository.GetAllBlogAsync();

            return Ok(_mapper.Map<IEnumerable<BlogDto>>(blogs));
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<BlogDto>> GetBlog(int id)
        {
            var blog = await _repository.GetBlogAsync(id);

            if (blog == null)
                return NotFound();

            return Ok(_mapper.Map<BlogDto>(blog));
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

        [HttpPut]
        [Route("{id:int}")]
        public async Task<ActionResult> UpdateBlog(int id, [FromBody] BlogCreateDto blogCreateDto)
        {
            var blog = await _repository.GetBlogAsync(id);

            var updateBlog = _mapper.Map(blogCreateDto, blog);

            _repository.UpdateBlog(updateBlog);
            await _repository.SaveChangesAsync();

            return Ok("Updated Successfully");
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult> DeleteBlog(int id)
        {
            var blog = await _repository.GetBlogAsync(id);

            if (blog == null)
                return NotFound();

            _repository.DeleteBlog(blog);
            await _repository.SaveChangesAsync();

            return Ok("Deleted Successfully");
        }
    }
}
