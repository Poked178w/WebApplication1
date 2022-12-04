using System.ComponentModel.DataAnnotations;

namespace PartyInvites.Data.DbModels
{
    public class Role
    {
        [Key]
        public string? RoleN { get; set; }

        public List<Player> Players { get; set; } = new();
    }
}
