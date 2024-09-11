using Microsoft.EntityFrameworkCore;
using RealEstateApp.Data.DataModels.Entities;
using RealEstateApp.Data.DataModels.Models;
using RealEstateApp.Data.DbContexts;
using RealEstateApp.Data.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateApp.Data.Services.SqlImplementations
{
    public class UserService : IUserService
    {
        private readonly AppDbContext db;

        public UserService(AppDbContext db)
        {
            this.db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public async Task AddUserAsync(UserEntity user)
        {
            await db.Users.AddAsync(user);
        }

        public async Task DeleteUserAsync(int id)
        {
            UserEntity? userToDelete = await GetUserByIdAsync(id);
            if(userToDelete != null)
            {
                db.Users.Remove(userToDelete);
            }
        }

        public async Task<IEnumerable<UserEntity>> GetAllUsersAsync()
        {
            return await db.Users.OrderBy(user => user.Firstname).ToListAsync();
        }

        public async Task<(IEnumerable<UserEntity>, PaginationMetaData)> GetAllUsersAsync
            (string? firstName, string? lastName, UserRole? userRole, string? searchQuery, int pageNumber, int pageSize)
        {
            IQueryable<UserEntity> collection = db.Users as IQueryable<UserEntity>;

            if (!string.IsNullOrEmpty(firstName))
            {
                firstName = firstName.Trim();
                collection = collection.Where(user => user.Firstname == firstName);
            }
            if (!string.IsNullOrEmpty(lastName))
            {
                lastName = lastName.Trim();
                collection = collection.Where(user => user.Lastname == lastName);
            }
            if (userRole != null)
            {
                collection = collection.Where(user => user.UserRole == userRole);
            }
            if (!string.IsNullOrEmpty(searchQuery))
            {
                collection = collection.Where(user =>
                    user.Firstname.Contains(searchQuery) ||
                    user.Lastname.Contains(searchQuery));
            }

            int totalCount = await collection.CountAsync();
            PaginationMetaData paginationMetaData = new PaginationMetaData(totalCount, pageSize, pageNumber);

            var collectionToReturn = collection.OrderBy(user => user.UserId)
                .Skip(pageSize * (pageNumber - 1))
                .Take(pageSize)
                .ToListAsync();

            return (await collectionToReturn, paginationMetaData);
        }

        public async Task<UserEntity?> GetUserByIdAsync(int id)
        {
            return await db.Users.Where(user => user.UserId == id).FirstOrDefaultAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await db.SaveChangesAsync() >= 0;
        }
    }
}
