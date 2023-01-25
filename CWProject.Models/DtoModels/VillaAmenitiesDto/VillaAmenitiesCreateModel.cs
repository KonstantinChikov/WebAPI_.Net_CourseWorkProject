using CWProject.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CWProject.Models.DtoModels.VillaAmenitiesDto
{
    public class VillaAmenitiesCreateModel
    {
        public int VillaId { get; set; }
        [JsonIgnore]
        public Villas Villa { get; set; }
        public int AmenityId { get; set; }
        [JsonIgnore]
        public Amenities Amenity { get; set; }
    }
}
