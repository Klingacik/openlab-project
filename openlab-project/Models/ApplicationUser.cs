using Microsoft.AspNetCore.Identity;

namespace openlab_project.Models
{
    public class ApplicationUser : IdentityUser
    {
        public int Xp { get; set; }
        public GuildInfo? GuildInfo { get; set; }

    }
}