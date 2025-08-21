using GameCatalog.BL.domain;
using GameCatalog.DAL;

namespace GameCatalog.BL;

public class Manager(IRepository repo) : IManager
{
    public IEnumerable<Game> GetPopularGames()
    {
        return repo.FindPopularGames();
    }

    public Game GetGameById(Guid id)
    {
        return repo.FindGame(id);
    }

    public IEnumerable<Game> GetGames(string namePart)
    {
        return repo.FindGames(namePart);
    }

    public void CreateReview(string title, string content, int rating, string username, Guid gameId)
    {
        var account = repo.FindAccount(username);
        var game = repo.FindGame(gameId);
        var review = new Review {Title = title, Content = content, Rating = rating, Account = account, Game = game};
        repo.SaveReview(review);
    }

    public IEnumerable<Game> GetSuggestions(string username)
    {
        return repo.FindSuggestions(username);
    }

    public string RegisterAccount(string email, string username, string password)
    {
        return repo.RegisterAccount(email, username, password);
    }

    public async Task<string> Login(string identifier, string password)
    {
        return await repo.Login(identifier, password);
    }

    public void Logout()
    {
        repo.Logout();
    }
}