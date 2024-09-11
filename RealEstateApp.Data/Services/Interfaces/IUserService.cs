using RealEstateApp.Data.DataModels.Entities;
using RealEstateApp.Data.DataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateApp.Data.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserEntity?> GetUserByIdAsync(int id);
        Task<IEnumerable<UserEntity>> GetAllUsersAsync();
        Task<(IEnumerable<UserEntity>, PaginationMetaData)> GetAllUsersAsync
            (string? firstName, string? lastName, UserRole? userRole, string? searchQuery, int pageNumber, int pageSize);
        Task AddUserAsync(UserEntity user);
        Task DeleteUserAsync(int id);
        Task<bool> SaveChangesAsync();
    }
}
