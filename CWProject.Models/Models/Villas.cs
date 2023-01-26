using CWProject.Models.Models.BaseModels;
using System.ComponentModel.DataAnnotations.Schema;

namespace CWProject.Models.Models
{
    public class Villas : BaseModel
    {
        [Column(TypeName = "decimal(18,4)")]
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
