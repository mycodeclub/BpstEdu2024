using System.ComponentModel.DataAnnotations;

namespace BpstEducation.Models
{
    public class Batches
    {
        [Key]
        public int UniqueId { get; set; }
        public int CourseId { get; set; }
        public string BatchFees { get; set; }
        public string Trainer { get; set; }
        public string CoTrainer { get; set; }
        public string batchStartDate { get; set; }
        public string batchExpectedEndDate { get; set; } = string.Empty;
        public DateTime createdDate  { get; set; }
        public DateTime updatedDate  { get; set; }
    }
}
