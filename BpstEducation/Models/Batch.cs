
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BpstEducation.Models
{
    public class Batch
    {
        [Key]
        public int UniqueId { get; set; }
        public int BatchId { get; set; }
       
        
        public int CourseId { get; set; }
        [ForeignKey("CourseId")]
        public CourseCategory? Course { get; set; }



        public string Title { get; set; }
        public string Description
        {
            get; set;
        }
            
        public string Trainer { get; set; }
        public string AssisTrainer { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public int BatchFee { get; set; }
        public DateTime CreatedBy { get; set; }

        public DateTime LastUpdatedBy { get; set; }

    }
}
