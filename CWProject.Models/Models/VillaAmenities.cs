using CWProject.Models.Models.BaseModels;
using System.Text.Json.Serialization;

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
