using BpstEducation.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BpstEducation.NewModels
{
    public class StudentApplication
    {
        [Key]
        public int UniqueId { get; set; }
        public string ApplicationId { get; set; }
        [Required]
        public string FirstName { get; set; } = string.Empty;
       
        [Required]
        public string LastName { get; set; } = string.Empty;
        public string FullName { get { return $" {FirstName}  {LastName}"; } }
        public string FatherName { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public int StatusId { get; set; }
        [ForeignKey("StatusId")]
        public ApplicationStatus? ApplicationStatus { get; set; }
        public DateTime AppliedOn { get; set; }
        [NotMapped]
        public int NumberOfDays { get { return (AppliedOn - DateTime.Now).Days; } }
        [Required]
        public string MobileNumber { get; set; } = string.Empty;
        public string HRComment { get; set; } = string.Empty;

        public string EmailId { get; set; } = string.Empty;
        public string CollegeName { get; set; } = string.Empty;

        public string HighestQualification { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please select course")]
        public int CourseId { get; set; }

        [ForeignKey("CourseId")]
        public virtual Course? Course { get; set; }
        public string? Message { get; set; } = string.Empty;
        public string? ErrorLogDuringStudentGenration { get; set; } = string.Empty;
    }
}