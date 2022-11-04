using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace MvcApp.Models
{
    public class PlayersContext : DbContext
    {
        public DbSet<Player> Players { get; set; } = null!;
        public DbSet<Clan> Clans { get; set; } = null!;
        public DbSet<Platform> Platforms { get; set; } = null!;
        public PlayersContext(DbContextOptions<PlayersContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}