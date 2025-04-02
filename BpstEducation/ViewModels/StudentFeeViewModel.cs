using BpstEducation.Models;

namespace BpstEducation.ViewModels
{
    public class StudentFeeViewModel
    {
        public Student Student { get; set; }
        public StudentFee StudentFee { get; set; }
        public List<Batch> Batchs { get; set; }  

    }
}
