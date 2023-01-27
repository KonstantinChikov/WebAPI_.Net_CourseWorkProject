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

        public VillasModel Create(VillasCreateModel model)
        {
            var villa = _mapper.Map<Villas>(model);
            villa.User = _villasRepository.FindUser(model.UserId);
            villa.LocationType = _villasRepository.FindLocation(model.LocationTypeId);

            _villasRepository.Villas.Add(villa);
            _villasRepository.Save();
            return _mapper.Map<VillasModel>(villa);
        }
        public void Update(int id, VillasUpdateModel model)
        {
            var villa = _villasRepository.Villas
                .Include(x => x.LocationType)
                .Where(x => x.Id == id).SingleOrDefault();

            _mapper.Map(model, villa);

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
        public VillasModel GetById(int id) => _mapper.Map<VillasModel>(_villasRepository.GetById(id));
        public int GetCount() => _villasRepository.GetCount();
    }
}
