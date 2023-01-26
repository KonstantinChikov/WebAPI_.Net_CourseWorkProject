using CWProject.Models.Models.BaseModels;
using System.Text.Json.Serialization;

namespace CWProject.Models.Models
{
    public class LocationType : BaseModel
    {
        // One to many
        [JsonIgnore]
        public ICollection<Villas> Villas { get; set; }
    }
}
