using BpstEducation.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BpstEducation.NewModels
{
    public class StudentRegistration
    {
        [Key]
        public int UniqueId { get; set; }

        [Required]
        public string FullName { get; set; }
        public string FatherName { get; set; }
        public string Address { get; set; }
        public int StatusId { get; set; }
        public string RegistrationId { get; set; }
        public DateTime CreateDate { get; set; }

        [Required]
        public string MobileNumber { get; set; }

        [Required]
        public string EmailId { get; set; }
        public string CollegeName { get; set; }

        [Required]
        public string Qualification { get; set; }

        [Required]
        public int CourseId { get; set; }

        [ForeignKey("CourseId")]
        public virtual Course? Course { get; set; }
        public string Message { get; set; }


    }
}
