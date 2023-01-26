using CWProject.Models.Models;

namespace CWProject.Models.DtoModels.VillasDto
{
    public class VillasModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal PricePerNight { get; set; }

        public string Address { get; set; }

        // One to many
        public virtual LocationType LocationType { get; set; }

        // One to many
        public virtual User User { get; set; }

        // Many to many
        public IList<string> Amenities { get; set; }
    }
}
