using System.ComponentModel.DataAnnotations;

namespace PartyInvites.Data.DbModels
{
    public class Platform
    {
        [Key]
        public int Id { get; set; }
        public string? PlatformN { get; set; }

        public List<Player> Players { get; set; } = new();
    }
}
