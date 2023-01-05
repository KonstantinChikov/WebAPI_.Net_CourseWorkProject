using CWProject.Models.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CWProject.Models.DtoModels.VillasDto
{
    public class VillasCreateModel
    {
        [Required]
        public string Name { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal PricePerNight { get; set; }

        public string Info { get; set; }

        public string Address { get; set; }

        public int LocationTypeId { get; set; }

        //One to many
        [JsonIgnore]
        public virtual LocationType LocationType { get; set; }

        // One to many
        public virtual User User { get; set; }

        // Many to many
        [JsonIgnore]
        public ICollection<VillaAmenities> VillaAmenities { get; set; }
    }
}
