using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BpstEducation.Models
{
    public class Student
    {

        [Key]
        public int UniqueId { get; set; }

        [Display(Name = "Reg. No.")]
        public string RegistrationNumber { get { return "Edu_" + DateTime.Now.Year.ToString() + "_" + UniqueId.ToString(); } }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        [Display(Name = "First Name")]

        public string FirstName { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        [Display(Name = "Last Name")]

        public string LastName { get; set; }


        [NotMapped]
        public string? FullName { get { return FirstName + LastName; } }



        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$", ErrorMessage = "Email is not in proper format")]
        [DisplayName("Email-Id")]
        [Required(ErrorMessage = "Please enter a valid email id")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date Of Birth")]
        public DateTime DateOfBirth { get; set; }

        [Phone]
        [Display(Name = "Phone Number")]

        public string PhoneNumber { get; set; } = string.Empty;

        public string Address { get; set; }

        [Required]
        [RegularExpression(@"^\d{12}$", ErrorMessage = "Invalid Aadhaar number. It must be a 12-digit number.")]
        [Display(Name = "Aadhaar Num.")]
        public string AadhaarNumber { get; set; }

        [Required]
        [RegularExpression(@"^[A-Z]{5}\d{4}[A-Z]{1}$", ErrorMessage = "Invalid PAN number. Format should be: XXXXX1234X.")]
        [Display(Name = "Pan Num.")]
        public string PanNumber { get; set; }
        [NotMapped]


         ///<summary>
         ///
         /// Aadhar update 
         /// </summary>
        [DataType(DataType.Upload)]
        [Display(Name = "Upload Aadhar")]
        public IFormFile? Aadhar { get; set; }
        public string? AadharFileUrl { get; set; }
        public string? AadharName { get; set; }

        [NotMapped]
        [Display(Name = "Upload Pan")]
        public IFormFile? Pan { get; set; } 
        public string? PanName { get; set; } = string.Empty;

        public string? PanFileUrl { get; set; }

        [Display(Name = "Course Category")]
        public int CourseOfInterestId { get; set; }
        [ForeignKey("CourseOfInterestId")]
        [DeleteBehavior(DeleteBehavior.Restrict)]
        public Course? CourseOfInterest { get; set; }
        public int MyTrainingFee { get; set; }
        public int MyDiscount { get; set; }
        public List<StudentFee>? MySubmittedFeeTillNow { get; set; }
        //--------------------------------------------------------------
        [Display(Name = "My Remaining Fee")]

        public int MyRemainingFee
        {
            get
            {
                int _remainingFee = MyTrainingFee - MyDiscount;
                if (MySubmittedFeeTillNow != null && MySubmittedFeeTillNow.Count > 0)
                    _remainingFee = MySubmittedFeeTillNow.Sum(f => f.SubmittedFee) - MyDiscount;
                return _remainingFee;
            }
        }
        [Display(Name = "Registration Date")]
        public DateTime RegistrationDate { get; internal set; }
        public DateTime CreatedDate { get; internal set; }
        public DateTime LastUpdatedDate { get; internal set; }


        public bool IsDeleted { get; set; } = false;

        [NotMapped]
        public bool IncludingToBatch { get; set; }
        [NotMapped]
        public string StudentDisplayName { get { return FullName + "_" + RegistrationNumber; } }

        public string? LoginIdGuid { get; internal set; }
    }
}