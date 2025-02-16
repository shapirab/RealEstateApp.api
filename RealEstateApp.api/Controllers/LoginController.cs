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
        public async Task<ActionResult<UserDto>> Authenticate(LoginDto loggedinUser)
        {
            UserEntity? userEntity = await userService.GetUserByUsernameAsync(loggedinUser.Username);
            if(userEntity == null)
            {
                return Unauthorized("User does not exist");
            }

            var hmac = new HMACSHA512(userEntity.PasswordSalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loggedinUser.Password));

            for(int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != userEntity.PasswordHash[i])
                {
                    return Unauthorized("Wrong credentials");
                }
            }

            UserDto userToReturn = new UserDto
            {
                Username = loggedinUser.Username,
                Token = tokenService.CreateToken(userEntity)
            };
            return Ok(userToReturn);
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {
            if (await userService.UserExists(registerDto.Username))
            {
                return BadRequest("User is already in the system");
            }

            var hmac = new HMACSHA512();
            UserEntity userEntity = mapper.Map<UserEntity>(registerDto);
            userEntity.Username = registerDto.Username.ToLower();
            userEntity.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password));
            userEntity.PasswordSalt = hmac.Key;

            await userService.AddUserAsync(userEntity);
            bool success = await userService.SaveChangesAsync();

            if (!success)
            {
                return StatusCode(500, "Internal server error");
            }

            UserDto userDto = new UserDto
            {
                Username = userEntity.Username,
                Token = tokenService.CreateToken(userEntity)
            };
            return Ok(userDto);
        }
    }
}
