using CWProject.Models.Models.BaseModels;

namespace CWProject.Models.Models
{
    public class Amenities : BaseModel
    {
        // Many to many
        public ICollection<VillaAmenities> VillaAmenities{ get; set; }
    }
}
