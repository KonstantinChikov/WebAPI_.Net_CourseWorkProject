using CWProject.Models.Models;
using System.ComponentModel.DataAnnotations;

namespace CWProject.Models.DtoModels.VillasDto
{
    public class VillasCreateModel
    {
        [Required]
        public string Name { get; set; }
        public decimal PricePerNight { get; set; }

        public string Info { get; set; }

        public string Address { get; set; }

        public int LocationTypeId { get; set; }

        public int UserId { get; set; }
    }
}
