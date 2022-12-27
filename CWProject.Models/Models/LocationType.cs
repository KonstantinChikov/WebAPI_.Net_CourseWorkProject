using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using CWProject.Models.Models.BaseModels;

namespace CWProject.Models.Models
{
    public class LocationType : BaseModel
    {
        // One to many
        [JsonIgnore]
        public ICollection<Villas> Villas { get; set; }
    }
}
