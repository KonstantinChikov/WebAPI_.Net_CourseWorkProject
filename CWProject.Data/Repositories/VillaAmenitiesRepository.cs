using CWProject.Data.Repositories.Interfaces;
using CWProject.Models.DtoModels.VillaAmenitiesDto;
using CWProject.Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWProject.Data.Repositories
{
    public class VillaAmenitiesRepository : IVillaAmenitiesRepository
    {
        private readonly AppDbContext _appDbContext;
        public VillaAmenitiesRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }


        public List<VillaAmenities> GetAll => _appDbContext.VillaAmenities
              .Include(x => x.Amenities)
              .Include(x => x.Villas)
              .ThenInclude(x => x.User)
              .ToList();


        public DbSet<VillaAmenities> VillaAmenities => _appDbContext.VillaAmenities;
        public Villas FindVilla(int id) => _appDbContext.Villas.Include(x => x.User).SingleOrDefault(x => x.Id == id);
        public Amenities FindAmenities(int id) => _appDbContext.Amenities.SingleOrDefault(x => x.Id == id);
        public User FindUser(int id) => _appDbContext.Users.SingleOrDefault(x => x.Id == id);
        public VillaAmenities FindVillaAmenities(int amenitiesId, int villasId) => _appDbContext.VillaAmenities.Where(x => x.VillasId == villasId && x.AmenitiesId == amenitiesId).SingleOrDefault();
        public Villas FindVillaAmenitiesForUser(int userId) => _appDbContext.Villas.Include(x => x.User)
                                                             .SingleOrDefault(x => x.User.Id == userId);
        public void Save() => _appDbContext.SaveChanges();
    }
}
