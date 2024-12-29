using BpstEducation.Models;
using Microsoft.AspNetCore.Identity;

namespace BpstEducation.Services
{
    public interface IStudentServiceBAL
    {
        public Task<bool> CreateStudent(Student student);
        public Task<bool> MoveApplicationToBatch(int applicationId, int batchId);
        public Task<IdentityResult> AddStudentLoginDetails(Student student);
    }
}
