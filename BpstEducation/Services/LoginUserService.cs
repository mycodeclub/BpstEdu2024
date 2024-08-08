using BpstEducation.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Security.Claims;

namespace BpstEducation.Services
{
    public class LoginUserService : ILoginUserService
    {
        private readonly AppDbContext _dbContext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ITempDataDictionaryFactory _tempDataDictionaryFactory;
        public LoginUserService(AppDbContext dbContext, IHttpContextAccessor httpContextAccessor, ITempDataDictionaryFactory tempDataDictionaryFactory)
        {
            _dbContext = dbContext;
            _httpContextAccessor = httpContextAccessor;
            _tempDataDictionaryFactory = tempDataDictionaryFactory;
        }

        public string GetLoggedInUser()
        {
            return _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
        public string GetLoggedInUserId()
        {
            return _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        }
        public string GetLoggedInUserEmail()
        {
            return _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Email)?.Value;
        }
        public List<string> GetLoggedInUserRoles()
        {
            var roles = _httpContextAccessor.HttpContext.User.FindAll(ClaimTypes.Role).Select(roleClaim => roleClaim.Value).ToList();
            return roles;
        }

        public async Task<string> GetLayout()
        {
             var roles = GetLoggedInUserRoles();
             return roles.Contains("Admin") ? "~/Views/Shared/_AdminLayout.cshtml" : "~/Views/Shared/_StaffLayout.cshtml";
        }
    }
}
