using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BpstEducation.Models
{
    public class StudentBatch
    {

        [Key]
        public int UniqueId { get; set; }

        public int BatchId { get; set; }
        [ForeignKey("BatchId")]
        public Batch? Batch { get; set; }

        public int RegistrationId { get; set; }
        [ForeignKey("RegistrationId")]
        public Registration? Registration { get; set; }

        public int DiscountFee { get; set; }
        public int TotalAmt { get; set; }
        public int RemainingAmt { get; set; }






    }
}
