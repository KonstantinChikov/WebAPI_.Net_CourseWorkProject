using CWProject.Models.Models;
using System.ComponentModel.DataAnnotations;

namespace CWProject.Models.DtoModels.AmenitiesDto
{
    public class AmenitiesCreateModel
    {
        [Required]
        public string Name { get; set; }
    }
}
