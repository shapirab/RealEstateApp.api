using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstateApp.Data.DataModels.DTOs;
using RealEstateApp.Data.DataModels.Entities;
using RealEstateApp.Data.Services.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace RealEstateApp.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly ITokenService tokenService;
        private readonly IMapper mapper;

        public LoginController(IUserService userService, ITokenService tokenService, IMapper mapper)
        {
            this.userService = userService ?? throw new ArgumentNullException(nameof(userService));
            this.tokenService = tokenService ?? throw new ArgumentNullException(nameof(tokenService));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpPost("authenticate")]
        public async Task<ActionResult<UserDto>> Authenticate(UserDto user)
        {
            UserEntity? userEntity = await userService.GetUserByUsernameAndPasswordAsync(user.Username, user.Password);
            if(userEntity == null)
            {
                return Unauthorized();
            }
            user.Token = tokenService.CreateToken(userEntity);
            return Ok(user);
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {
            if (await userService.UserExists(registerDto.Username))
            {
                return BadRequest("User is already in the system");
            }

            UserEntity userEntity = mapper.Map<UserEntity>(registerDto);
            await userService.AddUserAsync(userEntity);
            bool success = await userService.SaveChangesAsync();

            if (!success)
            {
                return StatusCode(500, "Internal server error");
            }

            UserDto userDto = mapper.Map<UserDto>(registerDto);
            return Ok(userDto);
        }
    }
}
