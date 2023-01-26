using CWProject.Models.Models;
using System.Text.Json.Serialization;

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
        //[JsonIgnore]
        //public virtual User User { get; set; }

       
    }
}
