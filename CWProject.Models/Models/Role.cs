using CWProject.Models.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWProject.Models.Models
{
    public class Role : BaseModel
    {
        [InverseProperty("Role")]
        public ICollection<User> Users { get; set; }
    }
}
