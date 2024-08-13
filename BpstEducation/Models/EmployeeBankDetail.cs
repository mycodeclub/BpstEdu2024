using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BpstEducation.Models
{
    public class EmployeeBankDetail
    {
        [Key]
        public int UniqueId {  get; set; }
        public string? BankName {  get; set; }
        public string? BankAccNo {  get; set; }
        public string? IFSCCode {  get; set; }
    }
}
