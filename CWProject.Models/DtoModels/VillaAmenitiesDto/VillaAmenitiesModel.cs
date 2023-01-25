using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWProject.Models.DtoModels.VillaAmenitiesDto
{
    public class VillaAmenitiesModel
    {
        public int VillaId { get; set; }
        public string Villa { get; set; }
        public string User { get; set; }
        public int AmenityId { get; set; }
        public string Amenities { get; set; }
    }
}
