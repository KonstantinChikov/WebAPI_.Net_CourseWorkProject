using System.ComponentModel.DataAnnotations;

namespace CWProject.Models.Models.BaseModels
{
    public class BaseModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
