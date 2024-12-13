
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BpstEducation.Models
{
    [Display(Name = "Status")]
    [Table("ApplicationStatus")]
    public class ApplicationStatus
    {
        [Key]
        public int UniqueId { get; set; }

        [Required]
        public string RegistrationStatus { get; set; }

        public DateTime CreateDate { get; set; }
    }
}
