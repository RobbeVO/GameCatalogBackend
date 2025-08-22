using GameCatalog.BL;
using GameCatalog.UI_Server.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace GameCatalog.UI_Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ReviewsController(IManager manager) : Controller
{
    [HttpPost]
    public void Create([FromBody] CreateReviewDto request)
    {
        manager.CreateReview(request.Title, request.Content, request.Rating, request.Username, request.GameId);
    }
}