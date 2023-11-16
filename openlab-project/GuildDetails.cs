using openlab_project.Models;

namespace openlab_project
{
    public class GuildDetails
    {
        public int Id { get; set; }
        public required string? Name { get; set; }
        public required string? Description { get; set; }
        public int Capacity { get; set; }
        public int MembersCount { get; set; }
    }
}
