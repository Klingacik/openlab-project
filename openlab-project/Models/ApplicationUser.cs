﻿using Microsoft.AspNetCore.Identity;

namespace openlab_project.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? GuilD {  get; set; }
        public int XP { get; set; }
    }
}