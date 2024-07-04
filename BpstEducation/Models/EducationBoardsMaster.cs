using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BpstEducation.Models
{
    [Display(Name = "Education Boards")]
    [Table("EducationBoardsMaster")]
    public class EducationBoardsMaster
    {
        [Key]
        public int UniqueId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string ShortName { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
