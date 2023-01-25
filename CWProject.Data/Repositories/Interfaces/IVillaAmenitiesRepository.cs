using CWProject.Models.DtoModels.VillaAmenitiesDto;
using CWProject.Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
