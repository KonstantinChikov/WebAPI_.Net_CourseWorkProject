using CWProject.Models.Models;

namespace CWProject.Models.DtoModels.AmenitiesDto
{
    public class AmenitiesCreateModel
    {
        public string Name { get; set; }
        public ICollection<Villas> AmenityVillas { get; set; }
    }
}
