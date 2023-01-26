using AutoMapper;
using CWProject.Data.Repositories;
using CWProject.Data.Repositories.Interfaces;
using CWProject.Models.DtoModels.VillasDto;
using CWProject.Models.Models;
using CWProject.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using AppException = CWProject.Data.Exceptions.AppException;

namespace CWProject.Services
{
    public class VillasService : IVillasService
    {
        
        private readonly IVillasRepository _villasRepository;
        private readonly IMapper _mapper;
        public VillasService(IVillasRepository villasRepository, IMapper mapper)
        {
            _villasRepository = villasRepository;
            _mapper = mapper;
        }

        public Villas Create(Villas villa, int userId)
        {
            if (string.IsNullOrWhiteSpace(villa.Name))
                throw new AppException("Name is required");

            if (string.IsNullOrWhiteSpace(villa.Address))
                throw new AppException("Name is required");

            if (villa.PricePerNight == 0m)
                throw new AppException("Price is required");

            if (villa.LocationTypeId == 0)
                throw new AppException("LocationTypeId is required");

            villa.User = _villasRepository.FindUser(userId);
            villa.LocationType = _villasRepository.FindLocation(villa.Id);

            _villasRepository.Villas.Add(villa);
            _villasRepository.Save();
            return villa;
        }
        public void Update(Villas villaParam)
        {
            var villa = _villasRepository.Villas
                .Include(x => x.LocationType)
                .Where(x => x.Id == villaParam.Id).SingleOrDefault();

            if (!string.IsNullOrWhiteSpace(villaParam.Name))
                villa.Name = villaParam.Name;

            if (villaParam.PricePerNight == 0m)
                villa.PricePerNight = villa.PricePerNight;

            if (!string.IsNullOrWhiteSpace(villaParam.Address))
                 villa.Address = villaParam.Address;

            if (villaParam.LocationTypeId != 0)
                 villa.LocationTypeId = villaParam.LocationTypeId;

            _villasRepository.Villas.Update(villa);
            _villasRepository.Save();
        }
        public void Delete(int id)
        {
            var villa = _villasRepository.Villas.Find(id);

            if (villa != null)
            {
                _villasRepository.Villas.Remove(villa);
                _villasRepository.Save();
            }
        }

        public Villas FindVilla(int id) => _villasRepository.Villas.Include(x => x.User).SingleOrDefault(x => x.Id == id);
        public List<VillasModel> GetAll() => _villasRepository.GetAll.Select(_mapper.Map<VillasModel>).ToList();
        public VillasModel GetById(int id) => _villasRepository.GetById(id);
        public int GetCount()
        {
            return _villasRepository.GetCount();
        }
    }
}
