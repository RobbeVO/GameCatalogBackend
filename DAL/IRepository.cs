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
    string RegisterAccount(string email, string username, string password);
    Task<string> Login(string identifier, string password);
    void Logout();
}