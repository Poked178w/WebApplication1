using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PartyInvites.Data;
using PartyInvites.Models;
using System.Numerics;
using PartyInvites.Data.DbModels;

namespace MvcApp.Controllers
{
    public class HomeController : Controller
    {
        ApplicationContext db;
        public HomeController(ApplicationContext context)
        {
            db = context;

            // добавим начальные данные для тестирования
            if (!db.Platforms.Any())
            {
                Clan sssr = new Clan { NameClan = "SSSR" };
                Clan Disasters = new Clan { NameClan = "Disasters" };
                Clan Falcon = new Clan { NameClan = "Falcon" };
                Clan KillersEvil = new Clan { NameClan = "KillersEvil" };


                Platform Android = new Platform { PlatformN = "Android" };
                Platform IOS_Apple = new Platform { PlatformN = "IOS/Apple" };
                Platform Steam_Mygames = new Platform { PlatformN = "Steam/MY.games" };


                Player Player1 = new Player { Nickname = "WarrionCat", Clan = "sssr", Id = "KJFENF9", Platform = "Android" };
                Player Player2 = new Player { Nickname = "Hanter3000", Clan = "Disaster", Id = "D47UF35", Platform = "Android" };
                Player Player3 = new Player { Nickname = "Pilot-2D866IA", Clan = "sssr", Id = "2D866IA", Platform = "Android" };
                Player Player4 = new Player { Nickname = "HoverDOG", Clan = "Falcon", Id = "I8T7B5E", Platform = "IOS_Apple" };
                Player Player5 = new Player { Nickname = "Pilot-CL96U8E", Clan = "KillersEvil", Id = "CL96U8E", Platform = "Steam_Mygames" };
                Player Player6 = new Player { Nickname = "KDVKSbfsjD", Clan = "KillersEvil", Id = "CCE3758", Platform = "Steam_Mygames" };
                Player Player7 = new Player { Nickname = "Poked178", Clan = "Disaster", Id = "U3Q284G", Platform = "Android" };
                Player Player8 = new Player { Nickname = "keklol5D", Clan = "Falcon", Id = "75D8UH3", Platform = "IOS_Apple" };

                db.Clans.AddRange(sssr, Disasters, Falcon, KillersEvil);
                db.Platforms.AddRange(Android, IOS_Apple, Steam_Mygames);
                db.Players.AddRange(Player1, Player2, Player3, Player4, Player5, Player6, Player7, Player8);
                db.SaveChanges();
            }
        }

        public async Task<IActionResult> Index(SortState sortOrder)
        {
            IQueryable<Player>? players = db.Players;

            ViewData["IdSort"] = sortOrder == SortState.IdAsc ? SortState.IdDesc : SortState.IdAsc;
            ViewData["NicknameSort"] = sortOrder == SortState.NicknameAsc ? SortState.NicknameDesc : SortState.NicknameAsc;
            ViewData["PlafformSort"] = sortOrder == SortState.PlatformAsc ? SortState.PlatformDesc : SortState.PlatformAsc;
            ViewData["ClanSort"] = sortOrder == SortState.ClanAsc ? SortState.ClanDesc : SortState.ClanAsc;

            players = sortOrder switch
            {
                SortState.NicknameAsc => players.OrderBy(s => s.Nickname),
                SortState.NicknameDesc => players.OrderByDescending(s => s.Nickname),
                SortState.PlatformAsc => players.OrderBy(s => s.Platform),
                SortState.PlatformDesc => players.OrderByDescending(s => s.Platform),
                SortState.ClanAsc => players.OrderBy(s => s.Clan),
                SortState.ClanDesc => players.OrderByDescending(s => s.Clan),
                _ => players.OrderBy(s => s.Nickname),
            };

            return View(await players.AsNoTracking().ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Create(Player Player)
        {
            db.Players.Add(Player);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        // Код для удаления параметров участника Т
        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            if (id != null)
            {
                Player Player = new Player { Id = id };
                db.Entry(Player).State = EntityState.Deleted;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return NotFound();
        }

        // Код для изменения параметров участника Т
        public async Task<IActionResult> Edit(string id)
        {
            if (id != null)
            {
                Player? player = await db.Players.FirstOrDefaultAsync(p => p.Id == id);

                if (player != null) return View(player);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Player player)
        {
            db.Players.Update(player);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}