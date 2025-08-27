using GameCatalog.BL;
using GameCatalog.UI_Server.Dtos;
using GameCatalog.UI_Server.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace GameCatalog.UI_Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountsController(IManager manager) : Controller
{
    [HttpPost]
    public AccountDto Register([FromBody] RegisterAccountDto request)
    {
        var username = manager.RegisterAccount(request.Email, request.Username, request.Password);
        return username == null ? null : Mapper.ToAccountDto(username, User.IsInRole("ADMIN"));
    }

    [HttpPost]
    [Route("login")]
    public async Task<AccountDto> Login([FromBody] LoginDto request)
    {
        var username = await manager.Login(request.Identifier, request.Password);
        return username == null ? null : Mapper.ToAccountDto(username, User.IsInRole("ADMIN"));
    }

    [HttpPost]
    [Route("logout")]
    public void Logout()
    {
        manager.Logout();
    }
}