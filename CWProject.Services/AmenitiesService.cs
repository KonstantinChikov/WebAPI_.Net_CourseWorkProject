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

        public AmenitiesModel Create(AmenitiesCreateModel model)
        {
            var amenity = _mapper.Map<Amenities>(model);
            _amenitiesRepository.Amenities.Add(amenity);
            _amenitiesRepository.Save();
            return _mapper.Map<AmenitiesModel>(amenity);
            
        }

        public void Update(int id, AmenitiesUpdateModel model)
        {
            var amenities = _amenitiesRepository.Amenities.Find(id);

            _mapper.Map(model, amenities);

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
