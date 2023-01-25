using CWProject.Models.DtoModels.LocationTypeDto;
using CWProject.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWProject.Services.Interfaces
{
    public interface ILocationTypeService
    {
        List<LocationTypeModel> GetAll();
        LocationTypeModel GetById(int id);
        LocationType Create(LocationType locationType);
        void Update(LocationType locationType);
        void Delete(int id);
    }
}
