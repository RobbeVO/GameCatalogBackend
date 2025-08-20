using GameCatalog.BL;
using GameCatalog.BL.domain;
using GameCatalog.UI_Server.Dtos;
using GameCatalog.UI_Server.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace GameCatalog.UI_Server.Controllers;

[Route("api/[controller]")]
public class GamesController(IManager manager) : Controller
{
    [HttpGet]
    [Route("{id:guid}")]
    public GameDetailsDto Get(Guid id)
    {
        return GameMapper.ToDetailsDto(manager.GetGameById(id));
    }
    
    public IEnumerable<SearchGameDto> Get(string namePart)
    {
        return GameMapper.ToSearchDtos(manager.GetGames(namePart));
    }
}