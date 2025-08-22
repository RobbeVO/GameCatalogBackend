using GameCatalog.BL;
using GameCatalog.UI_Server.Dtos;
using GameCatalog.UI_Server.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace GameCatalog.UI_Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HomeController(IManager mgr) : Controller
{
    [HttpGet]
    public IEnumerable<GameDto> PopularGames()
    {
        return GameMapper.ToDtos(mgr.GetPopularGames());
    }
}