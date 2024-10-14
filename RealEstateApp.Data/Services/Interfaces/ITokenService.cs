using RealEstateApp.Data.DataModels.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateApp.Data.Services.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(UserEntity user);
    }
}
