using CWProject.Models.DtoModels.AmenitiesDto;
using CWProject.Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWProject.Data.Repositories.Interfaces
{
    public interface IAmenitiesRepository
    {
        
        List<AmenitiesModel> GetAll { get; }
        AmenitiesModel GetById(int id);
        DbSet<Amenities> Amenities { get; }
        void Save();
        
    }
}
