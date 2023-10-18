using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using openlab_project.Data;
using openlab_project.Models;
using System.Security.Claims;
using System.Xml.XPath;

namespace openlab_project.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly ApplicationDbContext _context;
        public UserController(ILogger<UserController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public ActionResult<UserInfo> GetUser()
        {
            var user = new UserInfo();
            {
                user.Xp = 1000;
                user.Guild = "internet warriors";
            };
            return Ok(user);
        }
        
    }
}
