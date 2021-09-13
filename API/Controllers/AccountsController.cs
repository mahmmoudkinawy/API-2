using API.DTOs.Users;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class AccountsController : BaseApiController
    {
        private readonly ITokenRepository _tokenRepository;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountsController(UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            ITokenRepository tokenRepository, IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenRepository = tokenRepository;
            _mapper = mapper;
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {
            if (await UserExists(registerDto.Username))
                return Unauthorized("Username is taken");

            var user = _mapper.Map<AppUser>(registerDto);

            user.UserName = registerDto.Username.ToLower();

            var result = await _userManager.CreateAsync(user, registerDto.Password);

            if (!result.Succeeded)
                return BadRequest(result.Errors);

            return new UserDto
            {
                Username = user.UserName,
                Token = _tokenRepository.CreateToken(user)
            };
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var user = await _userManager.Users
                .SingleOrDefaultAsync(x => x.UserName == loginDto.Username);

            if (user == null)
                return Unauthorized("Invalid username");

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password,
                false);

            if (!result.Succeeded)
                return Unauthorized();

            return new UserDto
            {
                Username = user.UserName,
                Token = _tokenRepository.CreateToken(user)
            };
        }

        private async Task<bool> UserExists(string username)
        {
            return await _userManager.Users.AnyAsync(x => x.UserName == username.ToLower());
        }

    }
}
