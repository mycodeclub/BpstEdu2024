using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BpstEducation.Models
{

    [Display(Name = "Registration")]
    [Table("RegistrationForm")]
    public class Registration
    {
        [Key]
        public int UniqueId { get; set; }

        public int? StatusId { get; set; }
        [ForeignKey("StatusId")]
        public RegistrationStatusMaster? Status { get; set; }

        [Display(Name = "Total Fees")]
        public string? TotalFees { get; set; }
        public string? Discount { get; set; }

        [NotMapped]
        [Display(Name = "Remaining Fees")]
        public string? RemainingFees { get; set; }

        [NotMapped]
        [Display(Name = "Fees Installment")]
        public string? InstallmentFees { get; set; }

        public string? RegistrationId { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string FullName { get; set; }

        [Required]
        [Display(Name = "Father Name")]
        public string FatherName { get; set; }

        [Display(Name = "Address")]
        public string Address { get; set; }

        [Display(Name = "College Name")]
        public string CollegeName { get; set; }



        [Display(Name = " Qualification")]
        [Required]

        public string Qualification { get; set; }

        [Display(Name = "Application For")]
        public int? ApplicationFor { get; set; }

        [ForeignKey("ApplicationFor")]
        public CourseCategory? Course { get; set; }
 
        [Display(Name = "Message")]
        public string Message { get; set; }

        [Required(ErrorMessage = "You must provide a phone number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Provide a Valid Mobile Number.")]
        [Display(Name = "Mobile Number")]
        public string MobileNumber { get; set; }

        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Provide a Valid Mobile Number.")]
        [Display(Name = "Alternate Mobile Number")]
        public string? AlternateMobileNumber { get; set; }

        [Display(Name = "Email Id")]
        [EmailAddress]
        [Required]
        public string EmailId { get; set; }

        public DateTime CreateDate { get; set; }

        public bool IsReview {  get; set; }

        public string? feedback {  get; set; }


    }
}
