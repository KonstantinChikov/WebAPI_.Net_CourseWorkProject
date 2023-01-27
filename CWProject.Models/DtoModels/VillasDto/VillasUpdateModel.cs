using CWProject.Models.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CWProject.Models.DtoModels.VillasDto
{
    public class VillasUpdateModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public decimal PricePerNight { get; set; }

        [Required]
        public string Info { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public int LocationTypeId { get; set; }

        [Required]
        public int UserId { get; set; }

    }
}
