using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace BpstEducation.Models
{
    public abstract class Employee
    {
        [Key]
        public int UniqueId { get; set; }
        public Guid? LoggedInUserId { get; set; }
        [DisplayName("First Name")]
        public string? FirstName { get; set; }

        [DisplayName("Last Name")]
        public string? LastName { get; set; }



        [NotMapped]
        public string? FullName { get { return FirstName + " " + LastName; } }

        [DisplayName("Employee Id ")]
        public string EmpId { get; set; }
        [DisplayName("EmpProfile")]
        public string EmpProfile { get; set; } = string.Empty;

        [DisplayName("Email")]
        public string Email { get; set; } = string.Empty;

        [DisplayName("Date Of Birth")]
        public DateTime DateOfBirth { get; set; }

        public int? AddressId { get; set; }
        [DisplayName("Address Id")]
        [ForeignKey("AddressId")]
        public Address? Address { get; set; }

        [DisplayName("Phone Number")]
        public string PhoneNumber { get; set; }
        public int Experience { get; set; }
    }
}
