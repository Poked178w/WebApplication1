using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using PartyInvites.Data;
using PartyInvites.Data.DbModels;
using PartyInvites.Models;

namespace PartyInvites.Services;

/// <summary>
/// Сервис для работы с данными игроков
/// </summary>
public class PlayersService
{
    private readonly ApplicationContext _dbContext;

    public PlayersService(ApplicationContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    /// <summary>
    /// Добавляем в базу начальные данные, если база пуста
    /// </summary>
    public void SeedData()
    {
        //если данные в базе уже есть, то просто возвращаемся
        if (_dbContext.Platforms.Any())
            return;

        //иначе, добавим начальные данные для тестирования
        var clans = new Clan[]
        {
            new() { NameClan = "SSSR" },
            new() { NameClan = "Disasters" },
            new() { NameClan = "Falcon" },
            new() { NameClan = "KillersEvil" }
        };

        var platforms = new Platform[]
        {
            new() { PlatformN = "Android" },
            new() { PlatformN = "IOS/Apple" },
            new() { PlatformN = "Steam/MY.games" }
        };

        var players = new Player[]
        {
            new() { Nickname = "WarrionCat", Clan = "SSSR", Id = "KJFENF9", Platform = "Android" },
            new() { Nickname = "Hanter3000", Clan = "Disaster", Id = "D47UF35", Platform = "IOS/Apple" },
            new() { Nickname = "Pilot-2D866IA", Clan = "SSSR", Id = "2D866IA", Platform = "Steam/MY.games" },
        };

        _dbContext.Clans.AddRange(clans);
        _dbContext.Platforms.AddRange(platforms);
        _dbContext.Players.AddRange(players);
        _dbContext.SaveChanges();
    }

    /// <summary>
    /// Получение списка игшроков для отображения в представлении
    /// </summary>
    public async Task<List<Player>> GetPlayersList(SortState sortOrder, ViewDataDictionary viewData)
    {
        IQueryable<Player>? players = _dbContext.Players;

        viewData["IdSort"] = sortOrder == SortState.IdAsc ? SortState.IdDesc : SortState.IdAsc;
        viewData["NicknameSort"] = sortOrder == SortState.NicknameAsc ? SortState.NicknameDesc : SortState.NicknameAsc;
        viewData["PlafformSort"] = sortOrder == SortState.PlatformAsc ? SortState.PlatformDesc : SortState.PlatformAsc;
        viewData["ClanSort"] = sortOrder == SortState.ClanAsc ? SortState.ClanDesc : SortState.ClanAsc;

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

        return await players.AsNoTracking().ToListAsync();
    }

    /// <summary>
    /// Добавить игрока
    /// </summary>
    public async Task AddPlayerAsync(Player player)
    {
        _dbContext.Players.Add(player);
        await _dbContext.SaveChangesAsync();
    }

    /// <summary>
    /// Удалить игрока
    /// </summary>
    public async Task DeletePlayerAsync(string id)
    {
        var player = new Player { Id = id };

        //TODO: я не уверен что это сработает, лучше использовать _dbContext.Players.Remove
        _dbContext.Entry(player).State = EntityState.Deleted;
        await _dbContext.SaveChangesAsync();
    }

    /// <summary>
    /// Изменить игрока
    /// </summary>
    public async Task EditPLayerAsync(Player player)
    {
        _dbContext.Players.Update(player);
        await _dbContext.SaveChangesAsync();
    }
}