using RealEstateApp.Data.DataModels.DTOs;
using RealEstateApp.Data.DataModels.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateApp.Data.Services.Interfaces
{
    public interface IPropertyService
    {
        Task<PropertyEntity?>GetPropertyByIdAsync(int id);
        Task<IEnumerable<PropertyEntity>> GetAllPropertiesAsync();
        Task<(IEnumerable<PropertyEntity>, PaginationMetaData)> GetAllPropertiesAsync
            (string? address, string? city, string? state, string? searchQuery, int pageNumber, int pageSize);
        Task AddPropertyAsync(PropertyEntity property);
        Task DeletePropertyAsync(int id);
        Task<bool> SaveChangesAsync();
    }
}
