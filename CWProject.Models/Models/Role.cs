using CWProject.Models.Models.BaseModels;
using System.ComponentModel.DataAnnotations.Schema;

namespace CWProject.Models.Models
{
    public class Role : BaseModel
    {
        [InverseProperty("Role")]
        public ICollection<User> Users { get; set; }
    }
}
