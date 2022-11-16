using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
namespace PartyInvites.Models
{
    public class AppDbInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            var userManager = new ApplicationPlayerManager(new UserStore<ApplicationPlayer>(context));

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            // Все роли
            var role1 = new IdentityRole { Name = "admin" };
            var role2 = new IdentityRole { Name = "vip" };
            var role3 = new IdentityRole { Name = "user" };

            // Добавил все роли в базу данных
            roleManager.Create(role1);
            roleManager.Create(role2);
            roleManager.Create(role3);

            // Создаем участников
            var admin = new ApplicationPlayer { Email = "poked2000k@mail.ru", UserName = "poked2000k@mail.ru" };
            string password = "ad46D_ewr3";
            var result = userManager.Create(admin, password);

            // Если создание прошло успешно то...
            if (result.Succeeded)
            {
                // ...добавляем для участника роль
                userManager.AddToRole(admin.Id, role1.Name);
                userManager.AddToRole(admin.Id, role2.Name);
                userManager.AddToRole(admin.Id, role3.Name);
            }

            base.Seed(context);
        }
    }
}