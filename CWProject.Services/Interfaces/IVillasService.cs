using CWProject.Models.DtoModels.VillasDto;
using CWProject.Models.Models;

namespace CWProject.Services.Interfaces
{
    public interface IVillasService
    {
        List<VillasModel> GetAll();
        VillasModel GetById(int id);
        VillasModel Create(VillasCreateModel model);
        void Update(int id, VillasUpdateModel model);
        void Delete(int id);
        Villas FindVilla(int id);
        int GetCount();
    }
}
