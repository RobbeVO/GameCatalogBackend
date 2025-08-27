namespace GameCatalog.UI_Server.Dtos;

public record GameDetailsDto(Guid Id, string Name, string Description, string ImageUrl, IEnumerable<string> Genres, IEnumerable<ReviewDto> Reviews, double AvgRating);