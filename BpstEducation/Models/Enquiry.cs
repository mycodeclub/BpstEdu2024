using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BpstEducation.Models
{
    [Display(Name = "Contact Us")]
    [Table("Enquiry")]
    public class Enquiry
    {
        [Key]
        public int UniqueId { get; set; }

        [Required]
        public string Name { get; set; }

        [Display(Name = "Mobile Number")]
        [Required]
        public string Mobile { get; set; }

        [Display(Name = "Alternate Mobile Number")]
        public string AltContactNumber { get; set; }

        [Display(Name = "Email Id")]
        public string Email { get; set; }

        public string Address { get; set; }

        [Required]
        public string Subject { get; set; }

        [Required]
        public string Message { get; set; }

        public DateTime CreateDate { get; set; }
    }
}
