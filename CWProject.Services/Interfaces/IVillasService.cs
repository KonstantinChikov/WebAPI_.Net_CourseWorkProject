using CWProject.Models.DtoModels.VillasDto;
using CWProject.Models.Models;

namespace CWProject.Services.Interfaces
{
    public interface IVillasService
    {
        List<VillasModel> GetAll();
        VillasModel GetById(int id);
        Villas Create(Villas villa, int userId);
        void Update(Villas villa);
        void Delete(int id);
        Villas FindVilla(int id);
        int GetCount();
    }
}
