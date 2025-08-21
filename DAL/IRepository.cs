using GameCatalog.BL.domain;

namespace GameCatalog.DAL;

public interface IRepository
{
    IEnumerable<Game> FindPopularGames();
    Game FindGame(Guid id);
    IEnumerable<Game> FindGames(string namePart);
    void SaveReview(Review review);
    Account FindAccount(string username);
    IEnumerable<Game> FindSuggestions(string username);
}