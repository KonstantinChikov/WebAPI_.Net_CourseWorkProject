using CWProject.Models.DtoModels.VillasDto;
using CWProject.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWProject.Services.Interfaces
{
    public interface IVillasService
    {
        List<VillasModel> GetAll();
        VillasModel GetById(int id);
        Villas Create(Villas villa, int userId);
        void Update(Villas villa);
        void Delete(int id);
        Villas FindVilla(int id);
    }
}
