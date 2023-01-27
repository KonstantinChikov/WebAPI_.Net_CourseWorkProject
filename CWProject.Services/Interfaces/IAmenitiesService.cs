using CWProject.Models.DtoModels.AmenitiesDto;
using CWProject.Models.Models;

namespace CWProject.Services.Interfaces
{
    public interface IAmenitiesService
    {
        
        List<AmenitiesModel> GetAll();
        AmenitiesModel GetById(int id);
        AmenitiesModel Create(AmenitiesCreateModel model);
        void Update(int id, AmenitiesUpdateModel model);
        void Delete(int id);

        int GetCount();
        
    }
}
