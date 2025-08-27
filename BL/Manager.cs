using System.Text;
using System.Text.Json;
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

    public async Task<Guid?> CreateGame(string name, string description, string imageUrl)
    {
        var game = new Game {Name = name, Description = description, ImageUrl = imageUrl};
        var genres = await GenerateGenres(game.Name, game.Description);
        game.Genres = genres;
        return repo.SaveGame(game) ? game.Id : null;
    }

    private static async Task<IEnumerable<Genre>> GenerateGenres(string name, string description)
    {
        var apiKey = Environment.GetEnvironmentVariable("HF_Api_Key");
        var client = new HttpClient();
        client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");

        var text = $"{name}: {description}";
        var labels = Enum.GetNames(typeof(Genre)).ToList();

        var data = new
        {
            inputs = text,
            parameters = new
            {
                candidate_labels = labels,
                multi_label = true
            }
        };

        var json = JsonSerializer.Serialize(data);
        var response = await client.PostAsync(
            "https://api-inference.huggingface.co/models/facebook/bart-large-mnli",
            new StringContent(json, Encoding.UTF8, "application/json")
        );

        var resultJson = await response.Content.ReadAsStringAsync();
        var result = JsonSerializer.Deserialize<HFResult>(resultJson);

        var filtered = new List<string>();
        for (var i = 0; i < result!.labels.Count; i++)
        {
            if (result.scores[i] >= 0.4f)
                filtered.Add(result.labels[i]);
        }

        var genres = filtered
            .Select(Enum.Parse<Genre>)
            .ToList();
        
        return genres;
    }
}