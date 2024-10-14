using AutoMapper;
using RealEstateApp.Data.DataModels.DTOs;
using RealEstateApp.Data.DataModels.Entities;

namespace RealEstateApp.api.Profiles
{
    public class RealEstateProfile : Profile
    {
        public RealEstateProfile()
        {
            CreateMap<UserDto, UserEntity>();
            CreateMap<UserEntity, UserDto>();

            CreateMap<RegisterDto, UserEntity>();
            CreateMap<UserEntity, RegisterDto>();

            CreateMap<PropertyDto, PropertyEntity>();
            CreateMap<PropertyEntity, PropertyDto>();
        }
    }
}
