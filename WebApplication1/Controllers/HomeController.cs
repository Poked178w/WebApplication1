using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PartyInvites.Data;
using PartyInvites.Models;
using PartyInvites.Data.DbModels;
using PartyInvites.Services;
using Microsoft.AspNetCore.Authorization;

namespace MvcApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationContext _dbContext;
        private readonly PlayersService _playersService;

        public HomeController(ApplicationContext context, PlayersService playersService)
        {
            _dbContext = context ?? throw new ArgumentNullException(nameof(context));
            _playersService = playersService ?? throw new ArgumentNullException(nameof(playersService));

            playersService.SeedData();
        }

        public async Task<IActionResult> Index(SortState sortOrder)
        {
            var players = await _playersService.GetPlayersList(sortOrder, ViewData);

            return View(players);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Player player)
        {
            await _playersService.AddPlayerAsync(player);

            return RedirectToAction("Index");
        }

        // Код для удаления параметров участника Т
        [HttpPost]
        public async Task<IActionResult> Delete(string? id)
        {

            if (id is not null)
            {
                await _playersService.DeletePlayerAsync(id);

                return RedirectToAction("Index");
            }

            return NotFound();
        }

        // Код для изменения параметров участника Т
        public async Task<IActionResult> Edit(string? id)
        {
            if (id is null) return NotFound();

            var player = await _dbContext.Players.FirstOrDefaultAsync(p => p.Id == id);

            if (player is not null) return View(player);

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Player player)
        {
            await _playersService.EditPLayerAsync(player);
            return RedirectToAction("Index");
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationPlayer { UserName = model.Email, Email = model.Email };
                var result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    // если создание прошло успешно, то добавляем роль пользователя
                    await UserManager.AddToRoleAsync(user.Id, "user");
                    await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);

                    return RedirectToAction("Index", "Home");
                }
                AddErrors(result);
            }

            return View(model);
        }

        [Authorize(Roles = "admin")]
        public ActionResult About()
        {
            ViewBag.Message = "Страница описания вашего приложения.";

            return View();
        }
    }
}