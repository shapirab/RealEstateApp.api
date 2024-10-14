using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstateApp.Data.DataModels.DTOs;
using RealEstateApp.Data.DataModels.Entities;
using RealEstateApp.Data.DataModels.Models;
using RealEstateApp.Data.Services.Interfaces;
using System.Text.Json;

namespace RealEstateApp.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly IMapper mapper;
        private readonly int maxPageSize = 20;

        public UsersController(IUserService userService, IMapper mapper)
        {
            this.userService = userService ?? throw new ArgumentNullException(nameof(userService));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        [Authorize(Policy = "ManagerOnly")]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetAllUsers
            (string? firstName, string? lastName, UserRole? userRole, string? searchQuery, int pageNumber = 1, int pageSize = 10)
        {
            if(pageSize > maxPageSize)
            {
                pageSize = maxPageSize;
            }
            var (userEntities, paginationMetaData) =
                await userService.GetAllUsersAsync(firstName, lastName, userRole, searchQuery, pageNumber, pageSize);

            Response.Headers.Append("X-Pagination", JsonSerializer.Serialize(paginationMetaData));
            return Ok(mapper.Map<IEnumerable<UserDto>>(userEntities));
        }

        [HttpGet("{id}")]
        [Authorize(Policy = "ManagerOnly")]
        public async Task<ActionResult<UserDto>> GetUserById(int id)
        {
            UserEntity? userEntity = await userService.GetUserByIdAsync(id);
            if(userEntity == null)
            {
                return NotFound("User with provided id was not found");
            }
            return Ok(mapper.Map<UserDto>(userEntity));
        }
    }
}
