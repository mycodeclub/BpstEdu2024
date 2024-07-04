using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BpstEducation.Models
{
    public class CodeHelper
    {
        [Key]
        public int UniqueId { get; set; }
        public int SubjectId { get; set; }
        [ForeignKey("SubjectId")]
        public Subject Subject { get; set; } 
        [Display(Name = "Topic")]
        public string Topic { get; set; }
        [Display(Name = "Topic Description")]
        public string TopicDescription { get; set; } 
        [Display(Name = "Answer Line 1")]
        public string AnswerLine1 { get; set; }
        [Display(Name = "Detail Answer and Description")]
        public string AnswerText { get; set; }
        public string Tags { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public bool IsActive { get; set; }
    }
}
