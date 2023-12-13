using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using openlab_project.Data;
using openlab_project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using openlab_project.Data.Migrations;

namespace OpenLabProject1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GuildController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GuildController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<GuildDetails> GetGuildInformation()
        {
            IEnumerable<GuildInfo> dbGuilds = _context.Guild;

            return dbGuilds.Select(dbGuilds => new GuildDetails
            {
                Id = dbGuilds.Id,
                Name = dbGuilds.Name,
                Description = dbGuilds.Description,
                Capacity = dbGuilds.Capacity,
                MembersCount = GetguildMembersCount(dbGuilds.Id)
            });
        }

        [HttpPost("join")]
        public IActionResult JoinGuild([FromBody] JoinGuildRequest request)
        {
            try
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                var user = _context.ApplicationUsers.Include(u => u.GuildInfo).FirstOrDefault(u => u.Id == userId);

                var guild = _context.Guild.FirstOrDefault(g => g.Id == request.GuildId);

                if (user == null || guild == null)
                {
                    return NotFound(new { message = "User or guild not found." });
                }

                if (guild.Members.Count >= guild.Capacity)
                {
                    return BadRequest(new { message = "Guild is already full." });
                }

                user.GuildInfo = guild; 
                _context.SaveChanges();

                return Ok(new GuildDetails
                {
                    Id = guild.Id,
                    Name = guild.Name,
                    Description = guild.Description,
                    Capacity = guild.Capacity,
                    MembersCount = GetguildMembersCount(guild.Id)
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal server error." });
            }
        }

        [HttpPost("leave")]
        public IActionResult LeaveGuild([FromBody] LeaveGuildRequest request)
        {
            try
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                var user = _context.ApplicationUsers.Include(u => u.GuildInfo).FirstOrDefault(u => u.Id == userId);

                if (user == null || user.GuildInfo == null)
                {
                    return NotFound(new { message = "User or guild not found." });
                }

                // Remove the user from the guild
                user.GuildInfo = null;
                _context.SaveChanges();

                return Ok(new { message = "Successfully left guild." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal server error." });
            }
        }

        [HttpGet("{id}")]
        public ActionResult<GuildDetails> GetGuildDetails(int id)
        {
            var guild = _context.Guild
                              .Where(g => g.Id == id)
                              .Select(dbGuild => new GuildDetails
                              {
                                  Id = dbGuild.Id,
                                  Name = dbGuild.Name,
                                  Description = dbGuild.Description,
                                  Capacity = dbGuild.Capacity,
                                  MembersCount = _context.Users
                                                      .Count(u => u.GuildInfo.Id == dbGuild.Id)
                              })
                              .FirstOrDefault();

            if (guild == null)
            {
                return NotFound(new { message = "Guild not found." });
            }

            return guild;
        }

        private int GetguildMembersCount(int guildId)
        {
            IQueryable<ApplicationUser> users = _context.Users.Include(applicationUser => applicationUser.GuildInfo).AsNoTracking();

            return users.Count(u => u.GuildInfo.Id == guildId);
        }
    }

    public class JoinGuildRequest
    {
        public int GuildId { get; set; }
    }

    public class LeaveGuildRequest
    {
        public int GuildId { get; set; }
    }

    public class GuildDetails
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int Capacity { get; set; }
        public int MembersCount { get; set; }
    }
}

    
