using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BpstEducation.Models
{
    public class Fee
    {
        [Key]
        public int UniqueId { get; set; }

        public int StudentId { get; set; }
        [ForeignKey("StudentId")]
        public Registration Registration { get; set; }

        public string FeeInstallment { get; set; }
        public DateTime FeeSubmittingDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastUpdatedDate { get; set; }
    }
}
