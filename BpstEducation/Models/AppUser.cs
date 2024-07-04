using Microsoft.AspNetCore.Identity;

namespace BpstEducation.Models
{
    public class AppUser : IdentityUser
    {
        public int AddressId { get; set; }
        public string ProfileImgUrl { get; set; }
    }
}
