using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CWProject.Models.Models.BaseModels;

namespace CWProject.Models.Models
{
    public class Amenities : BaseModel
    {
        // Many to many
        public ICollection<VillaAmenities> VillaAmenities{ get; set; }
    }
}
