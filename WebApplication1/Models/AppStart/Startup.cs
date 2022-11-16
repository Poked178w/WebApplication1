using Microsoft.Owin;
using Owin;
using Reg_Log.Models;
using Microsoft.Owin.Security.Cookies;
using Microsoft.AspNet.Identity;
using PartyInvites.Models;

[assembly: OwinStartup(typeof(AspNetIdentityApp.Startup))]

namespace Reg_Log.Models
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // настраиваем контекст и менеджер
            app.CreatePerOwinContext<ApplicationContext>(ApplicationContext.Create);
            app.CreatePerOwinContext<ApplicationPlayerManager>(ApplicationPlayerManager.Create);
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
            });
        }
    }
}