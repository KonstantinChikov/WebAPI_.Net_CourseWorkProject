using CWProject.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CWProject.Models.DtoModels.LocationTypeDto
{
    public class LocationTypeCreateModel
    {
        public string Name { get; set; }

        [JsonIgnore]
        public ICollection<Villas> Villas { get; set; }
    }
}
