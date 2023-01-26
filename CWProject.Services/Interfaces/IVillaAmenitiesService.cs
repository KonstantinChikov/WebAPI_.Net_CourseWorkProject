using CWProject.Models.DtoModels.VillaAmenitiesDto;
using CWProject.Models.Models;

namespace CWProject.Services.Interfaces
{
    public interface IVillaAmenitiesService
    {
        List<VillaAmenitiesModel> GetAll();
        VillaAmenities Create(VillaAmenities villa);
        User FindUser(int id);
        Villas FindVilla(int userId);
        Villas FindVillaAmenitiesForUser(int userId);
        void Delete(int amenityId, int villaId);
        int GetCount();
    }
}
