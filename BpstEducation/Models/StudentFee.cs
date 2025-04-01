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

        /// <summary>
        /// ForeignKey For BatchStudent Table 
        /// </summary>
        public int BatchStudentId { get; set; }
        public int StudentId { get; set; }

        public int SubmittedFeeAmount { get; set; }
        public string ?Description { get; set; }
        public DateTime FeeSubmittingDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public string? PaymentMethod { get; set; }
        public IFormFile? PaymentProof { get; set; }
        public string? PaymentProofPath{get; set;}

        
    }
}
