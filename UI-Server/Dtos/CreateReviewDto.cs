using System.ComponentModel.DataAnnotations;

namespace GameCatalog.UI_Server.Dtos;

public record CreateReviewDto(string Title, string Content, [Range(0, 5)] int Rating, string Username, Guid GameId);