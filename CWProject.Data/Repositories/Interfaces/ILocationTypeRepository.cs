using CWProject.Models.DtoModels.LocationTypeDto;
using CWProject.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace CWProject.Data.Repositories.Interfaces
{
    public interface ILocationTypeRepository
    {
        List<LocationTypeModel> GetAllLocations { get; }
        LocationType GetLocationById(int Id);
        DbSet<LocationType> Locations { get; }
        void Save();
        int GetCount();
    }
}
