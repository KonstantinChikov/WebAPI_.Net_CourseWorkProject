using CWProject.Data.Repositories.Interfaces;
using CWProject.Models.DtoModels.VillasDto;
using CWProject.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace CWProject.Data.Repositories
{
    public class VillasRepository : IVillasRepository
    {
        private readonly AppDbContext _appDbContext;
        public VillasRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }


        public List<Villas> GetAll => _appDbContext.Villas
                .Include(x => x.User)
                .Include(x => x.LocationType)
                .Include(x => x.VillaAmenities)
                .ThenInclude(x => x.Amenities)
                .ToList();

        public Villas GetById(int id) => _appDbContext.Villas
                .Include(x => x.VillaAmenities)
                .Include(x => x.LocationType)
                .Include(x => x.User)
                .Where(x => x.Id == id).SingleOrDefault();
        public DbSet<Villas> Villas => _appDbContext.Villas;
        public User FindUser(int id) => _appDbContext.Users.Where(x => x.Id == id).FirstOrDefault();
        public LocationType FindLocation(int id) => _appDbContext.LocationTypes.Where(x => x.Id == id).FirstOrDefault();
        public void Save() => _appDbContext.SaveChanges();
        public int GetCount()
        {
            return _appDbContext.Set<Villas>().Count();
        }
    }
}
