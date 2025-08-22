using GameCatalog.BL.domain;

namespace GameCatalog.BL;

public interface IManager
{
    IEnumerable<Game> GetPopularGames();
    Game GetGameById(Guid id);
    IEnumerable<Game> GetGames(string namePart);
    void CreateReview(string title, string content, int rating, string username, Guid gameId);
    IEnumerable<Game> GetSuggestions(string username);
    string RegisterAccount(string email, string username, string password);
    Task<string> Login(string identifier, string password);
    void Logout();
    Task<Game> CreateGame(string name, string description, string imageUrl);
}