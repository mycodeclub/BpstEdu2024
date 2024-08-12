using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BpstEducation.Models
{
    public class BatchStudent
    {

        [Key]
        public int UniqueId { get; set; }

        [Display(Name = "Batch Id")] 
        public int BatchId { get; set; }
        [ForeignKey("BatchId")]
        public Batch? Batch { get; set; } 
        [Display(Name = "Registration Id")]

        public int RegistrationId { get; set; }
        [ForeignKey("RegistrationId")]
        public Registration? Registration { get; set; }

        [Display(Name = "Discount Fee")] 
        public int DiscountFee { get; set; }

        [Display(Name = "Total Amt")] 
        public int TotalAmt { get; set; }

        [Display(Name = "Remaining Amt")] 
        public int RemainingAmt { get; set; }
    }
}
