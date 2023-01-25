using CWProject.Models.DtoModels.VillasDto;
using CWProject.Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWProject.Data.Repositories.Interfaces
{
    public interface IVillasRepository
    {
        List<Villas> GetAll { get; }
        VillasModel GetById(int id);
        DbSet<Villas> Villas { get; }
        User FindUser(int id);
        LocationType FindLocation(int id);
        public void Save();
    }
}
