using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
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
            var loggedInUser = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var user = await _userRepository.GetByUsernameAsync(loggedInUser);

            //var result = _mapper.Map<Blog>(blogCreateDto);
            var result = _mapper.Map<Blog>(blogCreateDto);

            if (result == null)
                return BadRequest("fuck you");

            user.Blogs.Add(result);
            await _userRepository.SaveAllAsync();

            return Ok("Created Successfully");
        }

    }
}
