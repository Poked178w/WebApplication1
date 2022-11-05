using System.ComponentModel.DataAnnotations;

namespace PartyInvites.Data.DbModels
{
    public class Clan
    {
        [Key]
        public int Id { get; set; }
        public string? NameClan { get; set; }

        public List<Player> Players { get; set; } = new(); //Платформы перекрывают кланы
    }
}
