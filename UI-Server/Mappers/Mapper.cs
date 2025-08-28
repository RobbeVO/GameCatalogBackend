using System.ComponentModel;
using GameCatalog.BL.domain;
using GameCatalog.UI_Server.Dtos;
using Microsoft.OpenApi.Extensions;

namespace GameCatalog.UI_Server.Mappers;

public static class Mapper
{
    public static IEnumerable<GameDto> ToDtos(IEnumerable<Game> games)
    {
        return games.Select(ToDto).ToList();
    }

    private static GameDto ToDto(Game game)
    {
        var genres = GetGameGenres(game);
        var avgRating = CalculateAverageRating(game);

        return new GameDto(game.Id, game.Name, game.Description, game.ImageUrl, genres, avgRating);
    }

    private static double CalculateAverageRating(Game game)
    {
        if (game.Reviews == null || !game.Reviews.Any()) return 0;
        return Math.Round(game.Reviews.Average(r => r.Rating), 1, MidpointRounding.AwayFromZero);
    }

    private static List<string> GetGameGenres(Game game)
    {
        return game.Genres
            .Select(genre => GetEnumDescription(genre))
            .ToList();
    }
    
    private static string GetEnumDescription(Enum value)
    {
        var fi = value.GetType().GetField(value.ToString());
        if (fi == null) return value.ToString();
        var attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
        return attributes.Length > 0 ? attributes[0].Description : value.ToString();
    }

    public static IEnumerable<SearchGameDto> ToSearchDtos(IEnumerable<Game> games)
    {
        return games.Select(ToSearchDto).ToList();
    }

    private static SearchGameDto ToSearchDto(Game game)
    {
        return new SearchGameDto(game.Id, game.Name, game.ImageUrl);
    }

    public static GameDetailsDto ToDetailsDto(Game game)
    {
        var reviews = new List<ReviewDto>();
        var avgRating = 0.0;
        if (game.Reviews != null)
        {
            reviews = game.Reviews.Select(review => new ReviewDto(review.Title, review.Content, review.Rating)).ToList();
            avgRating = CalculateAverageRating(game);
        }
        return new GameDetailsDto(game.Id, game.Name, game.Description, game.ImageUrl, GetGameGenres(game), reviews, avgRating);
    }

    public static AccountDto ToAccountDto(string username, bool isAdmin)
    {
        return new AccountDto(username, isAdmin);
    }
}