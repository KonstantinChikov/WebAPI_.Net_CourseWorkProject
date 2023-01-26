using CWProject.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace CWProject.Data.Repositories.Interfaces
{
    public interface IVillaAmenitiesRepository
    {
        List<VillaAmenities> GetAll { get; }
        DbSet<VillaAmenities> VillaAmenities { get; }
        Villas FindVilla(int id);
        Amenities FindAmenities(int id);
        User FindUser(int id);
        VillaAmenities FindVillaAmenities(int villaId, int amenityId);
        Villas FindVillaAmenitiesForUser(int userId);
        void Save();
        int GetCount();
    }
}
