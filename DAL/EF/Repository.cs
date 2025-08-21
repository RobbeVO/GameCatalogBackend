using GameCatalog.BL.domain;
using Microsoft.EntityFrameworkCore;

namespace GameCatalog.DAL.EF;

public class Repository(GcDbContext ctx) : IRepository
{
    public IEnumerable<Game> FindPopularGames()
    {
        return ctx.Games.Where(game => game.Reviews.Average(review => review.Rating) >= 4);
    }

    public Game FindGame(Guid id)
    {
        return ctx.Games
            .Include(game => game.Reviews)
            .SingleOrDefault();
    }

    public IEnumerable<Game> FindGames(string namePart)
    {
        return ctx.Games.Where(game => game.Name.StartsWith(namePart));
    }

    public void SaveReview(Review review)
    {
        ctx.Reviews.Add(review);
        ctx.SaveChanges();
    }

    public Account FindAccount(string username)
    {
        return ctx.Accounts.SingleOrDefault(account => account.Identity.UserName.ToLower().Equals(username.ToLower()));
    }

    public IEnumerable<Game> FindSuggestions(string username)
    {
        var account = ctx.Accounts.Include(account => account.Reviews).ThenInclude(review => review.Game).SingleOrDefault(account => account.Identity.UserName.ToLower().Equals(username.ToLower()));
        if (account != null)
        {
            var genres = new Dictionary<Genre, int>();
            foreach (var review in account.Reviews)
            {
                foreach (var genre in review.Game.Genres)
                {
                    if (!genres.TryAdd(genre, 1))
                    {
                        genres[genre]++;
                    }
                }
            }

            var freqGen = genres.SingleOrDefault(genre => genre.Value == genres.Values.Max());
            var suggestions = ctx.Games.AsEnumerable().Where(game => game.Genres.Contains(freqGen.Key));
            var playedGames = account.Reviews.Select(review => review.Game);
            return suggestions.Where(suggestion => !playedGames.Contains(suggestion));
        }
        
        return new List<Game>();
    }
}