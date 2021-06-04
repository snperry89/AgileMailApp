using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rockwood.Models
{
    public class CreateDepartment
    {
        [Required]
        [MinLength(1, ErrorMessage ="Please enter at least one character")]
        [MaxLength(50, ErrorMessage ="50 Character max")]
        public string DepartmentTitle { get; set; }
    }
}
