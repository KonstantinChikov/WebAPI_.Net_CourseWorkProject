using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using CWProject.Models.Models.BaseModels;

namespace CWProject.Models.Models
{
    public class VillaAmenities : BaseModel
    {
        public int VillasId { get; set; }
        [JsonIgnore]
        public Villas Villas { get; set; }
        public int AmenitiesId { get; set; }
        [JsonIgnore]
        public Amenities Amenities { get; set; }
    }
}
