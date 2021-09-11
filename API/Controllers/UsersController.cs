using API.DTOs;
using API.Entities;
using API.Extensions;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Authorize]
    public class UsersController : BaseApiController
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UsersController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MemberDto>>> GetAllUsers()
        {
            return Ok(await _userRepository.GetMembersAsync());
        }

        [HttpGet("{username}")]
        public async Task<ActionResult<MemberDto>> GetUser(string username)
        {
            return Ok(await _userRepository.GetMemberAsync(username));
        }

        [HttpPost("add-blog")]
        public async Task<ActionResult> AddBlogPost([FromBody] BlogCreateDto blogCreateDto)
        {
            var user = await _userRepository.GetByUsernameAsync(User.GetUsername());

            var result = _mapper.Map<Blog>(blogCreateDto);

            if (result == null)
                return BadRequest("fuck you");

            user.Blogs.Add(result);

            if (await _userRepository.SaveAllAsync())
                return Ok();

            return Ok("Created Successfully");
        }

        [HttpDelete("delete-blog/{id}")]
        public async Task<ActionResult> RemoveBlogPost(int id)
        {
            var user = await _userRepository.GetByUsernameAsync(User.GetUsername());

            var blog = user.Blogs.FirstOrDefault(x => x.Id == id);

            if (blog == null)
                return NotFound("The blog does not exist, Fuck you again");

            user.Blogs.Remove(blog);

            if (await _userRepository.SaveAllAsync())
                return Ok();

            return NoContent();
        }

    }
}
