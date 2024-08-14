using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BpstEducation.Models
{
    public class BatchStudent
    {

        [Key]
        public int UniqueId { get; set; }

        [Display(Name = "Batch")]
        public int BatchId { get; set; }
        [ForeignKey("BatchId")]
        public Batch? Batch { get; set; }


        [Display(Name = "Student")]
        public int StudentId { get; set; }
        [ForeignKey("StudentId")]
        public Student? Student { get; set; } 


        [Display(Name = "Discount Fee")]
        public int DiscountFee { get; set; }

        [Display(Name = "Total Amt")]
        public int TotalAmt { get; set; }

        [Display(Name = "Remaining Amt")]
        public int RemainingAmt { get; set; }
    }
}
