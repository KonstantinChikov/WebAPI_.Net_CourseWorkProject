using CWProject.Models.DtoModels.AmenitiesDto;
using CWProject.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace CWProject.Data.Repositories.Interfaces
{
    public interface IAmenitiesRepository
    {
        
        List<Amenities> GetAll { get; }
        AmenitiesModel GetById(int id);
        DbSet<Amenities> Amenities { get; }
        void Save();
        int GetCount();

    }
}
