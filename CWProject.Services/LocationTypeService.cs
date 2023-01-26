using CWProject.Data.Exceptions;
using CWProject.Data.Repositories;
using CWProject.Data.Repositories.Interfaces;
using CWProject.Models.DtoModels.LocationTypeDto;
using CWProject.Models.Models;
using CWProject.Services.Interfaces;

namespace CWProject.Services
{
    public class LocationTypeService : ILocationTypeService
    {
        private readonly ILocationTypeRepository _locationTypeRepository;
        public LocationTypeService(ILocationTypeRepository locationTypeRepository)
        {
            _locationTypeRepository = locationTypeRepository;
        }

        public List<LocationTypeModel> GetAll() => _locationTypeRepository.GetAllLocations;

        public LocationTypeModel GetById(int Id) => _locationTypeRepository.GetLocationById(Id);
        public LocationType Create(LocationType location)
        {
            if (string.IsNullOrWhiteSpace(location.Name))
                throw new AppException("Name is required");;

            _locationTypeRepository.Locations.Add(location);
            _locationTypeRepository.Save();
            return location;
        }
        public void Update(LocationType locationParam)
        {
            var location = _locationTypeRepository.Locations.Find(locationParam.Id);
            if (!string.IsNullOrWhiteSpace(locationParam.Name))
                location.Name = locationParam.Name;

            _locationTypeRepository.Locations.Update(location);
            _locationTypeRepository.Save();
        }
        public void Delete(int ID)
        {
            var locationType = _locationTypeRepository.Locations.Find(ID);
            if (locationType == null)
                throw new AppException("This Id doesn't exist");

            _locationTypeRepository.Locations.Remove(locationType);
            _locationTypeRepository.Save();
        }
        public int GetCount()
        {
            return _locationTypeRepository.GetCount();
        }
    }
}
