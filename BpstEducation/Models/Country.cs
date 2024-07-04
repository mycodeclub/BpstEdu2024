using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BpstEducation.Models
{
    [Table("Countries")]
    public class Country
    {
        [Key]
        public int UniqueId { get; set; }
        public string Name { get; set; }
    }
}
