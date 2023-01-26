using AutoMapper;
using CWProject.Data.Exceptions;
using CWProject.Data.Repositories;
using CWProject.Data.Repositories.Interfaces;
using CWProject.Models.DtoModels.VillaAmenitiesDto;
using CWProject.Models.Models;
using CWProject.Services.Interfaces;

namespace CWProject.Services
{
    public class VillaAmenitiesService : IVillaAmenitiesService
    {
        private readonly IVillaAmenitiesRepository _villaAmenitiesRepository;
        private readonly IMapper _mapper;
        public VillaAmenitiesService(IVillaAmenitiesRepository villaAmenitiesRepository, IMapper mapper)
        {
            _villaAmenitiesRepository = villaAmenitiesRepository;
            _mapper = mapper;
        }

        public VillaAmenities Create(VillaAmenities villaAmenity)
        {
            if (villaAmenity.VillasId == 0)
                throw new AppException("VillaId is required");

            if (villaAmenity.AmenitiesId == 0)
                throw new AppException("AmenityId is required");

            Villas hotelChecker = _villaAmenitiesRepository.FindVilla(villaAmenity.VillasId);
            Amenities facilityChecker = _villaAmenitiesRepository.FindAmenities(villaAmenity.AmenitiesId);

            if (hotelChecker == null)
                throw new AppException("Villa is not Existing! Add existing VillaId");

            if (facilityChecker == null)
                throw new AppException("Amenity is not Existing! Add existing AmenityId");

            _villaAmenitiesRepository.VillaAmenities.Add(villaAmenity);
            _villaAmenitiesRepository.Save();
            return villaAmenity;
        }

        public void Delete(int amenityId, int villaId)
        {
            VillaAmenities villaAmenity = _villaAmenitiesRepository.FindVillaAmenities(villaId, amenityId);

            if (villaAmenity != null)
            {
                _villaAmenitiesRepository.VillaAmenities.Remove(villaAmenity);
                _villaAmenitiesRepository.Save();
            }
        }

        public User FindUser(int id) => _villaAmenitiesRepository.FindUser(id);
        public Villas FindVilla(int id) => _villaAmenitiesRepository.FindVilla(id);
        public Villas FindVillaAmenitiesForUser(int userId) => _villaAmenitiesRepository.FindVillaAmenitiesForUser(userId);
        public List<VillaAmenitiesModel> GetAll() => _villaAmenitiesRepository.GetAll.Select(_mapper.Map<VillaAmenitiesModel>).ToList();
        public int GetCount()
        {
            return _villaAmenitiesRepository.GetCount();
        }
    }
}
