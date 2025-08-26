using GameCatalog.BL;
using GameCatalog.BL.domain;
using GameCatalog.UI_Server.Dtos;
using GameCatalog.UI_Server.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GameCatalog.UI_Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GamesController(IManager manager) : Controller
{
    [HttpGet]
    [Route("{id:guid}")]
    public GameDetailsDto Get(Guid id)
    {
        return Mapper.ToDetailsDto(manager.GetGameById(id));
    }
    
    [HttpGet]
    public IEnumerable<SearchGameDto> Get(string namePart)
    {
        return Mapper.ToSearchDtos(manager.GetGames(namePart));
    }

    [HttpGet]
    [Route("suggestions")]
    public IEnumerable<GameDto> Suggestions(string username)
    {
        var games = manager.GetSuggestions(username);
        return Mapper.ToDtos(games);
    }

    [HttpPost]
    [Authorize(Roles = "ADMIN")]
    public async Task<GameDetailsDto> Create([FromBody] CreateGameDto request)
    {
        var game = await manager.CreateGame(request.Name, request.Description, request.ImageUrl);
        return Mapper.ToDetailsDto(game);
    }
}