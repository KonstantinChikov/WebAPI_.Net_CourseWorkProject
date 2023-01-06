using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWProject.Models.DtoModels.AmenitiesDto
{
    public class AmenitiesModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<string> Villas { get; set; }
    }
}
