using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BpstEducation.Models
{

    [Display(Name = "Registration")]
    [Table("RegistrationForm")]
    public class RegistrationOld
    {
        [Key]
        public int UniqueId { get; set; }

        public int? StatusId { get; set; }
        [ForeignKey("StatusId")]
        public ApplicationStatus? Status { get; set; }

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
         [ForeignKey("AddressId")]
         public Address Address { get; set; }

        [Display(Name = "College Name")]
        public string CollegeName { get; set; }



        [Display(Name = " Qualification")]
        [Required]

        public string Qualification { get; set; }

        [Display(Name = "Application For")]
        public int? ApplicationFor { get; set; }

        [ForeignKey("ApplicationFor")]
        public Course? Course { get; set; }

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

        public bool IsReview { get; set; }

        public string? feedback { get; set; }

        [Display(Name = "Address")]
        public string OneLineAddress
        {
            get
            {
                StringBuilder _address = new StringBuilder();
                if (Address != null)
                {
                    if (!string.IsNullOrWhiteSpace(Address.AddressLine1))
                        _address.Append(Address.AddressLine1);
                    //if (!string.IsNullOrWhiteSpace(Address.AddressLine2))
                    //    _address.Append(" " + Address.AddressLine2);
                    //if (!string.IsNullOrWhiteSpace(Address.AddressLine3))
                    //    _address.Append(" " + Address.AddressLine3);
                    if ((Address.City != null))
                        _address.Append(" " + Address.City.Name);
                    if (Address.State != null)
                        _address.Append(" " + Address.State.Name);
                    if (Address.Country != null)
                        _address.Append(" " + Address.Country.Name);
                    if (!string.IsNullOrWhiteSpace(Address.PinCode))
                        _address.Append(" " + Address.PinCode);
                }
                return _address.ToString();
            }
        }

    }
}
