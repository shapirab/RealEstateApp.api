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
    public class PropertyController : ControllerBase
    {
        private readonly IPropertyService propertyService;
        private readonly IMapper mapper;
        private readonly int maxPageSize = 20;

        public PropertyController(IPropertyService propertyService, IMapper mapper)
        {
            this.propertyService = propertyService ?? throw new ArgumentNullException(nameof(propertyService));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PropertyDto>>> GetAllProperties
            (string? address, string? city, string? state, string? searchQuery, int pageNumber, int pageSize)
        {
            if(pageSize > maxPageSize)
            {
                pageSize = maxPageSize;
            }

            var (propertyEntities, paginationMetaData) = 
                await propertyService.GetAllPropertiesAsync(address, city, state, searchQuery, pageNumber, pageSize);

            Response.Headers.Append("X-Pagination", JsonSerializer.Serialize(paginationMetaData));
            return Ok(mapper.Map<IEnumerable<PropertyDto>>(propertyEntities));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PropertyDto>> GetPropertyById(int id)
        {
            PropertyEntity? propertyEntity = await propertyService.GetPropertyByIdAsync(id);
            if(propertyEntity == null)
            {
                return BadRequest("property with provided id was not found");
            }
            return Ok(mapper.Map<PropertyDto>(propertyEntity));
        }

        [HttpPost]
        [Authorize(Policy = "RegisteredUserOnly")]
        [Authorize(Policy = "ManagerOnly")]
        public async Task<ActionResult<bool>> AddProperty(PropertyDto property)
        {
            PropertyEntity propertyEntity = mapper.Map<PropertyEntity>(property);
            await propertyService.AddPropertyAsync(propertyEntity);
            return Ok(propertyService.SaveChangesAsync());
        }

        [HttpPut("{propertyID}")]
        [Authorize(Policy = "RegisteredUserOnly")]
        [Authorize(Policy = "ManagerOnly")]
        public async Task<ActionResult<bool>> UpdateProperty(int propertyID, PropertyDto updatedProperty)
        {
            PropertyEntity? propertyToUpdate = await propertyService.GetPropertyByIdAsync(propertyID);
            if(propertyToUpdate == null)
            {
                return BadRequest("property with the provided id was not found");
            }
            mapper.Map(updatedProperty, propertyToUpdate);
            return Ok(propertyService.SaveChangesAsync());
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = "RegisteredUserOnly")]
        [Authorize(Policy = "ManagerOnly")]
        public async Task<ActionResult<bool>> RemoveProperty(int id)
        {
            PropertyEntity? propertyToRemove = await propertyService.GetPropertyByIdAsync(id);
            if (propertyToRemove == null)
            {
                return BadRequest("property with the provided id was not found");
            }
            await propertyService.DeletePropertyAsync(id);
            return Ok(propertyService.SaveChangesAsync());
        }
    }
}
