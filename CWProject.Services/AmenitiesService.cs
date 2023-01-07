using CWProject.Data.Exceptions;
using CWProject.Data.Repositories.Interfaces;
using CWProject.Models.DtoModels.AmenitiesDto;
using CWProject.Models.Models;
using CWProject.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWProject.Services
{
    public class AmenitiesService : IAmenitiesService
    {
        
        private readonly IAmenitiesRepository _amenitiesRepository;
        public AmenitiesService(IAmenitiesRepository amenitiesRepository)
        {
            _amenitiesRepository = amenitiesRepository;
        }
        
        public List<AmenitiesModel> GetAll() => _amenitiesRepository.GetAll;

        public AmenitiesModel GetById(int id) => _amenitiesRepository.GetById(id);

        public Amenities Create(Amenities amenities)
        {
            throw new NotImplementedException();
            
            if (string.IsNullOrWhiteSpace(amenities.Name))
                throw new AppException("Name is required");

            var facilities = _amenitiesRepository.Amenities
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
            //throw new NotImplementedException();
            
            var amenities = _amenitiesRepository.Amenities.Find(amenitiesParm.Id);

            if (!string.IsNullOrWhiteSpace(amenitiesParm.Name))
                amenities.Name = amenitiesParm.Name;

            _amenitiesRepository.Amenities.Update(amenities);
            _amenitiesRepository.Save();
            
        }
        public void Delete(int id)
        {
            //throw new NotImplementedException();
            
               var facility = _amenitiesRepository.Amenities.Find(id);
            if (facility != null)
            {
                _amenitiesRepository.Amenities.Remove(facility);
                _amenitiesRepository.Save();
            }
            
        }
    }
}
