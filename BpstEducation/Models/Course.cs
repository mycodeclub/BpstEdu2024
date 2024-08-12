using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BpstEducation.Models
{
    public class Course
    {
        [Key]
        public int UniqueId { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
