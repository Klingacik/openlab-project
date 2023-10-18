using Microsoft.AspNetCore.Identity;

namespace openlab_project.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? Guild {  get; set; }
        public int Xp { get; set; }
    }
}