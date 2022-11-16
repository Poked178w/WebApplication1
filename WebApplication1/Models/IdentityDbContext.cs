using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace PartyInvites.Models
{
    public class ApplicationContext : IdentityDbContext<ApplicationPlayer>
    {
        public ApplicationContext() : base("IdentityDb") { }

        public static ApplicationContext Create()
        {
            return new ApplicationContext();
        }
    }
    public class ApplicationPlayer : IdentityUser
    {
        public int Year { get; set; }
        public ApplicationPlayer()
        {
        }
    }
}