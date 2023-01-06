using CWProject.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CWProject.Models.DtoModels.AmenitiesDto
{
    public class AmenitiesUpdateModel
    {
        public string Name { get; set; }

        [JsonIgnore]
        public ICollection<Villas> AmenityVillas { get; set; }
    }
}
