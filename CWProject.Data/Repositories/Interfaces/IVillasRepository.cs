using CWProject.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace CWProject.Data.Repositories.Interfaces
{
    public interface IVillasRepository
    {
        List<Villas> GetAll { get; }
        Villas GetById(int id);
        DbSet<Villas> Villas { get; }
        User FindUser(int id);
        LocationType FindLocation(int id);
        public void Save();
        int GetCount();
    }
}
