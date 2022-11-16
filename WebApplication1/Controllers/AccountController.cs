using System.Security.Claims;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PartyInvites.Models;

namespace PartyInvites.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Register(RegisterModel model)
        {
            throw new NotImplementedException();
        }

        public ActionResult Login(string returnUrl)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginModel model, string returnUrl)
        {
            throw new NotImplementedException();
        }
        
        [HttpGet]
        public ActionResult Logout()
        {
            return View();
        }
    }
}