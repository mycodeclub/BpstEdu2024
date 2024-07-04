using System.ComponentModel.DataAnnotations;

namespace BpstEducation.Models
{
    public class Contact
    {
        [Key]
        public int UniqueId { get; set; }
        public string yourName { get; set; }
        public string YourEmail { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }

    }
}
