using GameCatalog.BL.domain;

namespace GameCatalog.UI_Server.Dtos;

public record GameDto(string Name, string Description, string ImageUrl, IEnumerable<string> Genres);