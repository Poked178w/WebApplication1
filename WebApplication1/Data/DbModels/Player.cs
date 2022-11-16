using Microsoft.AspNet.Identity;
using System.ComponentModel.DataAnnotations;

namespace PartyInvites.Data.DbModels
{
    public class Player
    {
        [Key]
        public string Id { get; set; }
        public string Nickname { get; set; }
        public string Platform { get; set; }
        public string? Clan { get; set; }
        public int Score { get; set; }
        public int Victories { get; set; }
    }
}
