using GameCatalog.BL.domain;

namespace GameCatalog.BL;

public interface IManager
{
    IEnumerable<Game> GetPopularGames();
    Game GetGameById(Guid id);
    IEnumerable<Game> GetGames(string namePart);
    void CreateReview(string title, string content, int rating, string username, Guid gameId);
    IEnumerable<Game> GetSuggestions(string username);
}