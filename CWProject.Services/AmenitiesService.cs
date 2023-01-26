using AutoMapper;
using CWProject.Data.Exceptions;
using CWProject.Data.Repositories.Interfaces;
using CWProject.Models.DtoModels.AmenitiesDto;
using CWProject.Models.Models;
using CWProject.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CWProject.Services
{
    public class AmenitiesService : IAmenitiesService
    {
        
        private readonly IAmenitiesRepository _amenitiesRepository;
        private readonly IMapper _mapper;
        public AmenitiesService(IAmenitiesRepository amenitiesRepository, IMapper mapper)
        {
            _amenitiesRepository = amenitiesRepository;
            _mapper = mapper;
        }

        public List<AmenitiesModel> GetAll() => _amenitiesRepository.GetAll.Select(_mapper.Map<AmenitiesModel>).ToList();

        public AmenitiesModel GetById(int id) => _amenitiesRepository.GetById(id);

        public Amenities Create(Amenities amenities)
        {
            throw new NotImplementedException();
            
            if (string.IsNullOrWhiteSpace(amenities.Name))
                throw new AppException("Name is required");

            var amenity = _amenitiesRepository.Amenities
                .Include(x => x.VillaAmenities)
                .ThenInclude(x => x.Villas)
                .Select(x => new AmenitiesCreateModel()
                {
                    Name = x.Name,
                }).Where(x => x.Name == amenities.Name).SingleOrDefault();
            _amenitiesRepository.Amenities.Add(amenities);
            _amenitiesRepository.Save();
            return amenities;
            
        }

        public void Update(Amenities amenitiesParm)
        {
            var amenities = _amenitiesRepository.Amenities.Find(amenitiesParm.Id);

            if (!string.IsNullOrWhiteSpace(amenitiesParm.Name))
                amenities.Name = amenitiesParm.Name;

            _amenitiesRepository.Amenities.Update(amenities);
            _amenitiesRepository.Save();
            
        }
        public void Delete(int id)
        {
               var amenity = _amenitiesRepository.Amenities.Find(id);
            if (amenity != null)
            {
                _amenitiesRepository.Amenities.Remove(amenity);
                _amenitiesRepository.Save();
            }
            
        }
        public int GetCount()
        {
            return _amenitiesRepository.GetCount();
        }
    }
}
