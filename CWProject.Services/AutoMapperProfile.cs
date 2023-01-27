using AutoMapper;
using CWProject.Models.DtoModels;
using CWProject.Models.DtoModels.AmenitiesDto;
using CWProject.Models.DtoModels.LocationTypeDto;
using CWProject.Models.DtoModels.VillaAmenitiesDto;
using CWProject.Models.DtoModels.VillasDto;
using CWProject.Models.Models;

namespace CWProject.Services
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<AmenitiesCreateModel, Amenities>();
            CreateMap<Amenities, AmenitiesModel>();
            CreateMap<AmenitiesUpdateModel, Amenities>();

            CreateMap<VillasCreateModel, Villas>();
            CreateMap<Villas, VillasModel>();
            CreateMap<VillasUpdateModel, Villas>();

            CreateMap<VillaAmenitiesCreateModel, VillaAmenities>();
            CreateMap<VillaAmenities, VillaAmenitiesModel>();

            CreateMap<LocationTypeCreateModel, LocationType>();
            CreateMap<LocationType, LocationTypeModel>();
            CreateMap<LocationTypeUpdateModel, LocationType>();

            CreateMap<UserDto, User>();
            CreateMap<User, UserDto>();
        }
    }
}
