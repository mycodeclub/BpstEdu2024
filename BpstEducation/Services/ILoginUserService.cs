namespace BpstEducation.Services
{
    public interface ILoginUserService
    {
        public string GetLoggedInUser();
        public string GetLoggedInUserId();
        public string GetLoggedInUserEmail();
        public List<string> GetLoggedInUserRoles();
        public Task<string> GetLayout();
    }
}
