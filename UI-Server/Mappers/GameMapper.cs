using GameCatalog.BL.domain;
using GameCatalog.UI_Server.Dtos;

namespace GameCatalog.UI_Server.Mappers;

public static class GameMapper
{
    public static IEnumerable<GameDto> ToDtos(IEnumerable<Game> games)
    {
        return games.Select(ToDto).ToList();
    }

    private static GameDto ToDto(Game game)
    {
        var genres = GetGameGenres(game);

        return new GameDto(game.Name, game.Description, game.ImageUrl, genres);
    }

    private static IEnumerable<string> GetGameGenres(Game game)
    {
        return game.Genres.Select(genre => genre.ToString()).ToList();
    }

    public static IEnumerable<SearchGameDto> ToSearchDtos(IEnumerable<Game> games)
    {
        return games.Select(ToSearchDto).ToList();
    }

    private static SearchGameDto ToSearchDto(Game game)
    {
        return new SearchGameDto(game.Id, game.Name);
    }

    public static GameDetailsDto ToDetailsDto(Game game)
    {
        var reviews = new List<ReviewDto>();
        var avgRating = 0.0;
        if (game.Reviews != null)
        {
            reviews = game.Reviews.Select(review => new ReviewDto(review.Title, review.Content, review.Rating)).ToList();
            avgRating = Math.Round(game.Reviews.Average(r => r.Rating), 1, MidpointRounding.AwayFromZero);
        }
        
        return new GameDetailsDto(game.Id, game.Name, game.Description, game.ImageUrl, GetGameGenres(game), reviews, avgRating);
    }
}