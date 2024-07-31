using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BpstEducation.Models
{
    public class Students
    {
        [Key]
        public int UniqueId { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string LastName { get; set; }

        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$", ErrorMessage = "Email is not in proper format")]
        [DisplayName("Email-Id")]
        [Required(ErrorMessage = "Please enter a valid email id")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Phone]
        public string PhoneNumber { get; set; } = string.Empty;

        public string Address { get; set; }

        [Required]
        [RegularExpression(@"^\d{12}$", ErrorMessage = "Invalid Aadhaar number. It must be a 12-digit number.")]
        public string AadhaarNumber { get; set; }

        [Required]
        [RegularExpression(@"^[A-Z]{5}\d{4}[A-Z]{1}$", ErrorMessage = "Invalid PAN number. Format should be: XXXXX1234X.")]
        public string PanNumber
        {
            get; set;
        }
        [NotMapped]
        [Display(Name = "Upload Aadhar")]
        public IFormFile? Aadhar { get; set; }

        public string? AadharName { get; set; }

        [NotMapped]
        [Display(Name = "Upload Pan")]
        public IFormFile? Pan { get; set; }

        public string? PanName { get; set; } = string.Empty;

        [Display(Name = "Course Category")]
        public int CourseCategoryID { get; set; }
        [ForeignKey("CourseCategoryID")]
        public CourseCategory? CourseCategory { get; set; }
        public int Fees { get; set; }

    }
}