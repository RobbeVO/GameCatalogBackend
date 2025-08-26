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
        return Mapper.ToAccountDto(
            manager.RegisterAccount(
                request.Email, request.Username, request.Password),
            User.IsInRole("ADMIN")
        );
    }

    [HttpPost]
    [Route("login")]
    public async Task<AccountDto> Login([FromBody] LoginDto request)
    {
        return Mapper.ToAccountDto(await manager.Login(request.Identifier, request.Password), User.IsInRole("ADMIN"));
    }

    [HttpPost]
    [Route("logout")]
    public void Logout()
    {
        manager.Logout();
    }
}