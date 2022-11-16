using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using PartyInvites.Models;

public class ApplicationPlayerManager : PlayerManager<ApplicationPlayer>
{
    public ApplicationPlayerManager(IUserStore<ApplicationPlayer> store)
            : base(store)
    {
    }
    public static ApplicationPlayerManager Create(IdentityFactoryOptions<ApplicationPlayerManager> options,
                                            IOwinContext context)
    {
        ApplicationContext db = context.Get<ApplicationContext>();
        ApplicationPlayerManager manager = new ApplicationPlayerManager(new UserStore<ApplicationPlayer>(db));
        return manager;
    }
}