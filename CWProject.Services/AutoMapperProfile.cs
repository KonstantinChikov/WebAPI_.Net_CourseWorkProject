using AutoMapper;
using CWProject.Models.DtoModels;
using CWProject.Models.DtoModels.AmenitiesDto;
using CWProject.Models.DtoModels.VillasDto;
using CWProject.Models.Models;

namespace CWProject.Services
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Amenities, AmenitiesModel>();

            CreateMap<Villas, VillasModel>();

            CreateMap<UserDto, User>();
        }
    }
}
