namespace MvcApp.Models
{
    public class Player
    {
        public string Id { get; set; }
        public string Nickname { get; set; }
        public string Platform { get; set; }
        public string? ClanId { get; set; }
        public string? Clan { get; set; }
        public int Score { get; set; }
        public int Victories { get; set; }
    }
    public class Clan
    {
        public int Id { get; set; }
        public string? NameClan { get; set; }

        public List<Player> Players { get; set; } = new(); //Платформы перекрывают кланы
    }

    public class Platform
    {
        public string? PlatformN { get; set; }

        public List<Player> Players { get; set; } = new();
    }
}
