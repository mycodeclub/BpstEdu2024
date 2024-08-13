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

        [NotMapped]
        public string? FullName { get { return FirstName + LastName; } }
        public string JobRole { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; } = string.Empty;
        public int? Experience { get; set; }
        public string Address { get; set; } = string.Empty;
        public string LoginIdGuid { get; set; } = string.Empty;
    }
}
