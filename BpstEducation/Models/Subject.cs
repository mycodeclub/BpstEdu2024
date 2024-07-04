using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace BpstEducation.Models
{
    [Table("Subject")]
    public class Subject
    {
        [Key]
        public int UniqueId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ParentId { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime LastUpdatedDate { get; set; }
    }
}
