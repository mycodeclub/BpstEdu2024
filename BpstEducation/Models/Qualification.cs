using System.ComponentModel.DataAnnotations;

namespace BpstEducation.Models
{
    public class Qualification
    {
        [Key]
        public int UniqueId { get; set; }
        public string Name { get; set; }

    }
}
