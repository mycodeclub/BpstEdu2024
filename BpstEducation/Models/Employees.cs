using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BpstEducation.Models
{
    public class Employees
    {
        [Key]
        public int UniqueId { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
     


        [NotMapped]
        public string? FullName { get { return FirstName + LastName; } }
        public string JobRole { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; } = string.Empty;
        public int? Experience { get; set; }
        public string Address { get; set; } = string.Empty;
        public string LoginIdGuid { get; set; } = string.Empty;

        [Required]
        [RegularExpression(@"^\d{12}$", ErrorMessage = "Invalid Aadhaar number. It must be a 12-digit number.")]
        [Display(Name = "Aadhaar Num.")]
        public string AadhaarNumber { get; set; }

        [Required]
        [RegularExpression(@"^[A-Z]{5}\d{4}[A-Z]{1}$", ErrorMessage = "Invalid PAN number. Format should be: XXXXX1234X.")]
        [Display(Name = "Pan Num.")]
        public string PanNumber { get; set; }

        public string Qualification {  get; set; } = string.Empty;
    }
}
