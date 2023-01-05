using CWProject.Models.DtoModels.VillasDto;
using CWProject.Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWProject.Data.Repositories
{
    public class VillasRepository : IVillasRepository
    {
        private readonly AppDbContext _appDbContext;
        public VillasRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public List<VillasModel> GetAll => _appDbContext.Villas
                .Include(x => x.User)
                .Include(x => x.LocationType)
                .Include(x => x.VillaAmenities)
                .ThenInclude(x => x.Amenities)
                .Select(x => new VillasModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Address = x.Address,
                    PricePerNight = x.PricePerNight,
                    User = x.User,
                    LocationType = x.LocationType,
                    Amenities = x.VillaAmenities.Select(z => z.Amenities.Name).ToList(),
                }).ToList();

        public VillasModel GetById(int id) => _appDbContext.Villas
                .Include(x => x.VillaAmenities)
                .ThenInclude(x => x.Villas)
                .Select(x => new VillasModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Address = x.Address,
                    PricePerNight = x.PricePerNight,
                    User = x.User,
                    LocationType = x.LocationType,
                    Amenities = x.VillaAmenities.Select(z => z.Amenities.Name).ToList()
                }).Where(x => x.Id == id).SingleOrDefault();
        public DbSet<Villas> Villas => _appDbContext.Villas;
        public User FindUser(int id) => _appDbContext.Users.Where(x => x.Id == id).FirstOrDefault();
        public LocationType FindLocation(int id) => _appDbContext.LocationTypes.Where(x => x.Id == id).FirstOrDefault();
        public void Save() => _appDbContext.SaveChanges();
    }
}
