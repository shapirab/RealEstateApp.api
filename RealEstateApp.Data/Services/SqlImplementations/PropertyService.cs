using Microsoft.EntityFrameworkCore;
using RealEstateApp.Data.DataModels.DTOs;
using RealEstateApp.Data.DataModels.Entities;
using RealEstateApp.Data.DbContexts;
using RealEstateApp.Data.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateApp.Data.Services.SqlImplementations
{
    public class PropertyService : IPropertyService
    {
        private readonly AppDbContext db;

        public PropertyService(AppDbContext db)
        {
            this.db = db ?? throw new ArgumentNullException(nameof(db));
        }
       
        public async Task<(IEnumerable<PropertyEntity>, PaginationMetaData)> GetAllDepartmPropertiesAsync
            (string? address, string? city, string? state, string? searchQuery, int pageNumber, int pageSize)
        {
            IQueryable<PropertyEntity> collection = db.Properties as IQueryable<PropertyEntity>;

            if(!string.IsNullOrEmpty(address))
            {
                address = address.Trim();
                collection = collection.Where(p => p.StreetAddress == address);
            }
            if (!string.IsNullOrEmpty(city))
            {
                city = city.Trim();
                collection = collection.Where(p => p.City == city);
            }
            if (!string.IsNullOrEmpty(state))
            {
                state = state.Trim();
                collection = collection.Where(p => p.State == state);
            }
            if (!string.IsNullOrEmpty(searchQuery))
            {
                collection = collection.Where(p => 
                    p.StreetAddress.Contains(searchQuery) ||
                    p.City.Contains(searchQuery) ||
                    p.State.Contains(searchQuery));
            }

            int totalCount = await collection.CountAsync();
            PaginationMetaData paginationMetaData = new PaginationMetaData(totalCount, pageSize, pageNumber);

            var collectionToReturn = collection.OrderBy(p => p.PropertyId)
                .Skip(pageSize * (pageNumber - 1))
                .Take(pageSize)
                .ToListAsync();

            return (await collectionToReturn,  paginationMetaData);
        }

        public async Task<IEnumerable<PropertyEntity>> GetAllPropertiesAsync()
        {
            return await db.Properties.OrderBy(p => p.PropertyId).ToListAsync();
        }

        public async Task<PropertyEntity?> GetPropertyByIdAsync(int id)
        {
            return await db.Properties.Where(p => p.PropertyId == id).FirstOrDefaultAsync();
        }

        public async Task AddPropertyAsync(PropertyEntity property)
        {
            await db.Properties.AddAsync(property);
        }

        public async Task DeletePropertyAsync(int id)
        {
            PropertyEntity? propertyToDelete = await GetPropertyByIdAsync(id);
            if(propertyToDelete != null)
            {
                db.Properties.Remove(propertyToDelete);
            }
        }


        public async Task<bool> SaveChangesAsync()
        {
            return await db.SaveChangesAsync() >= 0;
        }
    }
}
