using CWProject.Models.Models;
using System.Text.Json.Serialization;

namespace CWProject.Models.DtoModels.LocationTypeDto
{
    public class LocationTypeCreateModel
    {
        public string Name { get; set; }

        [JsonIgnore]
        public ICollection<Villas> Villas { get; set; }
    }
}
