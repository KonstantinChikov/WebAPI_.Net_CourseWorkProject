using CWProject.Data.Repositories;
using CWProject.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CWProject.Services.Interfaces;
using CWProject.Models.DtoModels.VillasDto;
using CWProject.Models.Models;
using Realms.Sync.Exceptions;
using Microsoft.EntityFrameworkCore;
using CWProject.Data.Exceptions;
using AppException = CWProject.Data.Exceptions.AppException;

namespace CWProject.Services
{
    public class VillasService : IVillasService
    {
        
        private readonly IVillasRepository _villasRepository;
        public VillasService(IVillasRepository villasRepository)
        {
            _villasRepository = villasRepository;
        }
        
        public Villas Create(Villas villa, int userId)
        {
            //throw new NotImplementedException();
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
            //throw new NotImplementedException();
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
            //throw new NotImplementedException();
            var hotel = _villasRepository.Villas.Find(id);

            if (hotel != null)
            {
                _villasRepository.Villas.Remove(hotel);
                _villasRepository.Save();
            }
        }

        
        public Villas FindVilla(int id) => _villasRepository.Villas.Include(x => x.User).SingleOrDefault(x => x.Id == id);
        //{
            //throw new NotImplementedException();
        //}

        public List<VillasModel> GetAll() => _villasRepository.GetAll;
        //{
            //throw new NotImplementedException();
        //}

        public VillasModel GetById(int id) => _villasRepository.GetById(id);
        //{
            //throw new NotImplementedException();
        //}
    }
}
