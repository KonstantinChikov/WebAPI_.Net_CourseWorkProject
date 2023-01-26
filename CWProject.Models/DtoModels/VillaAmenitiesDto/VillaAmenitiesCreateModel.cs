using CWProject.Models.Models;
using System.Text.Json.Serialization;

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
