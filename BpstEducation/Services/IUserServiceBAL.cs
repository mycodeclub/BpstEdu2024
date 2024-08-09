using BpstEducation.Models;
using Microsoft.AspNetCore.Identity;

namespace BpstEducation.Services
{
    public interface IUserServiceBAL
    {
        public string GetLoggedInUser();
        public string GetLoggedInUserId();
        public string GetLoggedInUserEmail();
        public List<string> GetLoggedInUserRoles();
        public Task<string> GetLayout();

        public Task<bool> IsUserExist(string email);
        public Task<IdentityResult> AddUser(AppUser user, List<string> role);
        public Task<IdentityResult> UpldateLoggedInUserEmail(string oldEmail, string newEmail);
        public Task<IdentityResult> UpldateLoggedInUserPassword(string Email, string oldPassword, string newPassword);
    }
}
