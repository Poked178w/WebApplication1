using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace MvcApp.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Player> Players { get; set; } = null!;
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();   // создаем базу данных при первом обращении
        }
    }
}