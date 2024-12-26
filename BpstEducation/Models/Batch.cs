
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BpstEducation.Models
{
    public class Batch
    {
        [Key]
        public int UniqueId { get; set; }

        public int CourseId { get; set; }
        [ForeignKey("CourseId")]
        public Course? Course { get; set; }


        [Required(ErrorMessage = "Please select Valid Course")]
        [Display(Name = "Course")]
        public string Title { get; set; } = string.Empty;
        public string Duration { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        [Display(Name = "Trainer Id")]

        [ForeignKey("TrainerId")]
        public int TrainerId { get; set; }
        public Employees? Trainer { get; set; }

        [Display(Name = "Assis Trainer")]

        public string AssisTrainer { get; set; } = string.Empty;

        [Display(Name = "Start Date")]

        public DateTime StartDateTime { get; set; }
        public DateTime LastUpdatedDate { get; set; }

        [Display(Name = "Batch Fee")]
        public int BatchFee { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<BatchStudent>? Students { get; set; }

        [NotMapped]
        public string BatchDisplayName
        {
            get
            {
                var _displayName = new StringBuilder();
                if (!string.IsNullOrEmpty(Title))
                    _displayName.Append(Title + " | ");
                if (!string.IsNullOrEmpty(Description))
                    _displayName.Append(Description + " | ");
                _displayName.Append(StartDateTime.ToString("dd-MMM-yyyy") + " | ");
                _displayName.Append(StartDateTime.ToString("hh:mm:tt"));

                return _displayName.ToString();
            }
        }

        [NotMapped]
        public int RemaningDays
        {
            get { return (int)(StartDateTime - DateTime.Now).TotalDays; }
        }

    }
}
