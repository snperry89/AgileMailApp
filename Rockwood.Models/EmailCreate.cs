using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rockwood.Models
{
    public class EmailCreate
    {
        [MinLength(8, ErrorMessage = "Subject must be at least 8 characters.")]
        [MaxLength(42, ErrorMessage = "Subject too long.")]
        public string Subject { get; set; }
        public string EmailRecipient { get; set; }
        [MaxLength(1200, ErrorMessage = "Body cannot be more than 1200 characters.")]
        public string Body { get; set; }
    }
}
