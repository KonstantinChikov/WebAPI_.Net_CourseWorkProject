using CWProject.Data.Repositories.Interfaces;
using CWProject.Models.DtoModels.AmenitiesDto;
using CWProject.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace CWProject.Data.Repositories
{
    public class AmenitiesRepository : IAmenitiesRepository
    {
        private readonly AppDbContext _appDbContext;
        public AmenitiesRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public List<Amenities> GetAll => _appDbContext.Amenities
                .Include(x => x.VillaAmenities)
                .ThenInclude(x => x.Villas)
                .ToList();

        public AmenitiesModel GetById(int id) => _appDbContext.Amenities
        .Include(x => x.VillaAmenities)
                .ThenInclude(x => x.Villas)
                .Select(x => new AmenitiesModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Villas = x.VillaAmenities.Select(z => z.Villas.Name).ToList()
                }).Where(x => x.Id == id).SingleOrDefault();

        public void Save() => _appDbContext.SaveChanges();
        public DbSet<Amenities> Amenities => _appDbContext.Amenities;

        public int GetCount()
        {
            return _appDbContext.Set<Amenities>().Count();
        }
    }
}
