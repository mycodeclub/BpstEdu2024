
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BpstEducation.Models
{
    [Display(Name = "Status")]
    [Table("RegistrationStatusMaster")]
    public class RegistrationStatusMaster
    {
        [Key]
        public int UniqueId { get; set; }

        [Required]
        public string RegistrationStatus { get; set; }

        public DateTime CreateDate { get; set; }
    }
}
