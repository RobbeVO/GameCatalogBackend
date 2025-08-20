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
}