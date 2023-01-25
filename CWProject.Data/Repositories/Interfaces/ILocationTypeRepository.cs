using CWProject.Models.DtoModels.LocationTypeDto;
using CWProject.Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWProject.Data.Repositories.Interfaces
{
    public interface ILocationTypeRepository
    {
        List<LocationTypeModel> GetAllLocations { get; }
        LocationTypeModel GetLocationById(int Id);
        DbSet<LocationType> Locations { get; }
        void Save();
    }
}
