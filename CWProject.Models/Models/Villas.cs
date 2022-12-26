using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CWProject.Models.Models.BaseModels;

namespace CWProject.Models.Models
{
    public class Villas : BaseModel
    {
        public decimal PricePerNight { get; set; }

        public string Address { get; set; }

        public int LocationTypeId { get; set; }

        // One to many
        public virtual LocationType LocationType { get; set; }

        // One to many
        public virtual User User { get; set; }

        // Many to many
        public ICollection<VillaAmenities> VillaAmenities { get; set; }

        public ICollection<Amenities> Amenities { get; set; }

    }
}
