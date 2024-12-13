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
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get { return $" {FirstName}  {LastName}"; } }
        public string FatherName { get; set; }
        public string Address { get; set; }
        public int StatusId { get; set; }
        [ForeignKey("StatusId")]
        public ApplicationStatus ApplicationStatus { get; set; }
        public DateTime AppliedOn { get; set; }

        [Required]
        public string MobileNumber { get; set; }

        [Required]
        public string EmailId { get; set; }
        public string CollegeName { get; set; }

        [Required]
        public string HighestQualification { get; set; }

        [Required]
        public int CourseId { get; set; }

        [ForeignKey("CourseId")]
        public virtual Course? Course { get; set; }
        public string Message { get; set; }


    }
}
