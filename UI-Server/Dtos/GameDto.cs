namespace GameCatalog.UI_Server.Dtos;

public record GameDto(Guid Id, string Name, string Description, string ImageUrl, IEnumerable<string> Genres, double AvgRating);