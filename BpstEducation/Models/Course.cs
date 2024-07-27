using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BpstEducation.Models
{
    [Display(Name = "Course")]
    [Table("Course")]
    [Obsolete]
    public class Course
    {
        [Key]
        public int UniqueId { get; set; }

        [Required]
        [Display(Name ="Course Name")]
        public string CourseName { get; set; }

        [Display (Name ="Course Category")]
        public int CourseCategoryID { get; set; }
        [ForeignKey("CourseCategoryID")]
        public CourseCategory CourseCategory { get; set; }
        public string CourseDuration { get; set; }
        public int CourseFees { get; set; }
        public int feeDiscount { get; set; }

        public DateTime CreateDate { get; set; }
    }
}
