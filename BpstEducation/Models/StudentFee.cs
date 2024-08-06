using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BpstEducation.Models
{
    public class StudentFee
    {
        [Key]
        public int UniqueId { get; set; }

        public int StudentId { get; set; }
        [ForeignKey("StudentId")]
        public Students? Students { get; set; }

        public int BatchId { get; set; }
 
        public int SubmittedFee { get; set; }     
        

            
       
        public DateTime FeeSubmittingDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastUpdatedDate { get; set; }
    }
}
