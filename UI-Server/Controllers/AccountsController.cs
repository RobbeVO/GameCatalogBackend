using GameCatalog.BL;
using GameCatalog.UI_Server.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace GameCatalog.UI_Server.Controllers;

[Route("api/[controller]")]
public class AccountsController(IManager manager) :  Controller
{
    [HttpPost]
    public string Register([FromBody] RegisterAccountDto request)
    {
        return manager.RegisterAccount(request.Email, request.Username, request.Password);
    }

    [HttpPost]
    [Route("login")]
    public async Task<string> Login([FromBody] LoginDto request)
    {
        return await manager.Login(request.Identifier, request.Password);
    }

    [HttpPost]
    [Route("logout")]
    public void Logout()
    {
        manager.Logout();
    }
}