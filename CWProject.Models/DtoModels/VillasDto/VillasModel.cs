using CWProject.Models.DtoModels.AmenitiesDto;
using CWProject.Models.DtoModels.LocationTypeDto;
using CWProject.Models.Models;

namespace CWProject.Models.DtoModels.VillasDto
{
    public class VillasModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal PricePerNight { get; set; }

        public string Address { get; set; }

        public LocationTypeModel LocationType { get; set; }

        public UserDto User { get; set; }
    }
}
