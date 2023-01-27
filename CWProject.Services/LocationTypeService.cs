using AutoMapper;
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
        private readonly IMapper _mapper;
        public LocationTypeService(ILocationTypeRepository locationTypeRepository, IMapper mapper)
        {
            _locationTypeRepository = locationTypeRepository;
            _mapper = mapper;
        }

        public List<LocationTypeModel> GetAll() => _locationTypeRepository.GetAllLocations;

        public LocationTypeModel GetById(int Id) => _mapper.Map<LocationTypeModel>(_locationTypeRepository.GetLocationById(Id));
        public LocationTypeModel Create(LocationTypeCreateModel model)
        {
            var locType = _mapper.Map<LocationType>(model);
            _locationTypeRepository.Locations.Add(locType);
            _locationTypeRepository.Save();
            return _mapper.Map<LocationTypeModel>(locType);
        }
        public void Update(int id, LocationTypeUpdateModel model)
        {
            var location = _locationTypeRepository.Locations.Find(id);

            _mapper.Map(model, location);

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
