using CWProject.Models.DtoModels.LocationTypeDto;
using CWProject.Models.Models;

namespace CWProject.Services.Interfaces
{
    public interface ILocationTypeService
    {
        List<LocationTypeModel> GetAll();
        LocationTypeModel GetById(int id);
        LocationTypeModel Create(LocationTypeCreateModel model);
        void Update(int id, LocationTypeUpdateModel model);
        void Delete(int id);
        int GetCount();
    }
}
