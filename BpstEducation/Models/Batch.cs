
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BpstEducation.Models
{
    public class Batch
    {
        [Key]
        public int UniqueId { get; set; }

        [Required(ErrorMessage = "Please select Valid Course")]
        [Display(Name = "Course")]
        public int CourseId { get; set; }
        [ForeignKey("CourseId")]
        public CourseCategory? Course { get; set; } 
        public string Title { get; set; } = string.Empty;
        public string Duration { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty; 

        [ForeignKey("TrainerId")]
        public int TrainerId { get; set; }
        public Employees? Trainer { get; set; } 
        public string AssisTrainer { get; set; } = string.Empty;
        public DateTime StartDate { get; set; } 
        public DateTime LastUpdatedDate { get; set; }
        public int BatchFee { get; set; }
        public DateTime CreatedDate { get; set; }  
        public List<BatchStudent>? Students { get; set; }
    }
}
