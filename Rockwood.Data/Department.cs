using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rockwood.Data
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }

        [Required]
        public string DepartmentTitle { get; set; }

        //[ForeignKey(nameof(Users))]
        //public virtual List<Users> Users { get; set; }
    }
}
