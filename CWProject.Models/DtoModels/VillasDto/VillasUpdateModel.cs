using CWProject.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CWProject.Models.DtoModels.VillasDto
{
    public class VillasUpdateModel
    {
        public string Name { get; set; }
        public decimal PricePerNight { get; set; }
        public string Address { get; set; }
        // One to many
        public int LocationTypeId { get; set; }
        //public virtual LocationType LocationType { get; set; }

        // One to many
        [JsonIgnore]
        public virtual User User { get; set; }

        // Many to many
        [JsonIgnore]
        public ICollection<VillaAmenities> VillaAmenities { get; set; }
    }
}
