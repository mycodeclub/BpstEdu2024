using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BpstEducation.Models
{
    public class CourseCategory
    {
        [Key]
        public int UniqueId { get; set; }
        public string Name { get; set; }
    }
}
