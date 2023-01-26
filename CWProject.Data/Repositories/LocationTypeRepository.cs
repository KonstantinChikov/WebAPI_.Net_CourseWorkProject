using CWProject.Data.Repositories.Interfaces;
using CWProject.Models.DtoModels.LocationTypeDto;
using CWProject.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace CWProject.Data.Repositories
{
    public class LocationTypeRepository : ILocationTypeRepository
    {
        private readonly AppDbContext _appDbContext;
        public LocationTypeRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }


        public List<LocationTypeModel> GetAllLocations => _appDbContext.LocationTypes.
            Select(x => new LocationTypeModel()
            {
                Id = x.Id,
                Name = x.Name,
                Villas = x.Villas.Select(z => z.Name).ToList(),
            }).ToList();

        public LocationTypeModel GetLocationById(int Id) => _appDbContext.LocationTypes
                .Include(x => x.Villas)
                .Select(x => new LocationTypeModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Villas = x.Villas.Select(z => z.Name).ToList(),
                }).Where(x => x.Id == Id).SingleOrDefault();
        public DbSet<LocationType> Locations => _appDbContext.LocationTypes;
        public void Save() => _appDbContext.SaveChanges();
        public int GetCount()
        {
            return _appDbContext.Set<LocationType>().Count();
        }
    }
}
