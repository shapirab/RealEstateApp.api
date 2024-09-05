using Microsoft.EntityFrameworkCore;
using RealEstateApp.Data.DataModels.Entities;
using RealEstateApp.Data.DataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateApp.Data.DbContexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<UserEntity> Users { get; set; }
        public DbSet<PropertyEntity> Properties { get; set; }
    }
}
