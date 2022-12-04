using Microsoft.EntityFrameworkCore;
using PartyInvites.Data.DbModels;

namespace PartyInvites.Data
{
    public class ApplicationContext : DbContext
    {
        // = null!; не надо
        public DbSet<Player> Players { get; set; }
        public DbSet<Clan> Clans { get; set; }
        public DbSet<Platform> Platforms { get; set; }
        public DbSet<Role> Roles { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            
        }
    }
}