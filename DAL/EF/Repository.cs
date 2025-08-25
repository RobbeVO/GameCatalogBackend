using GameCatalog.BL.domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace GameCatalog.DAL.EF;

public class Repository(GcDbContext ctx, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager) : IRepository
{
    public IEnumerable<Game> FindPopularGames()
    {
        return ctx.Games
            .Include(game => game.Reviews)
            .Where(game => game.Reviews.Average(review => review.Rating) >= 4);
    }

    public Game FindGame(Guid id)
    {
        return ctx.Games
            .Include(game => game.Reviews)
            .SingleOrDefault(game => game.Id == id);
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
        if (account == null) return new List<Game>();
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

            var freqGen = genres.FirstOrDefault(genre => genre.Value == genres.Values.Max());
            var suggestions = ctx.Games.AsEnumerable().Where(game => game.Genres.Contains(freqGen.Key));
            var playedGames = account.Reviews.Select(review => review.Game);
            return suggestions.Where(suggestion => !playedGames.Contains(suggestion));
        }

    }

    public string RegisterAccount(string email, string username, string password)
    {
        if (ctx.Users.Any(u => u.UserName == username)) return null;
        var identityUser = new IdentityUser { Email = email, UserName = username };
        userManager.CreateAsync(identityUser, password).Wait();
        userManager.AddToRoleAsync(identityUser, "USER").Wait();
        ctx.Accounts.Add(new Account { Identity = ctx.Users.SingleOrDefault(user => user.UserName == username) });
        return ctx.SaveChanges() == 1 ? username : null;
    }

    public async Task<string> Login(string identifier, string password)
    {
        return identifier.Contains('@') ? await EmailLogin(identifier, password) : await UsernameLogin(identifier, password);
    }

    public void Logout()
    {
        signInManager.SignOutAsync().Wait();
    }

    public bool SaveGame(Game game)
    {
        ctx.Games.Add(game);
        return ctx.SaveChanges() == 1;
    }

    private async Task<string> EmailLogin(string email, string password)
    {
        var user = ctx.Users.SingleOrDefault(u => u.Email == email);
        if (user == null) return null;
        var result = await signInManager.PasswordSignInAsync(user, password, true, false);
        return result.Succeeded ? user.UserName : null;;
    }

    private async Task<string> UsernameLogin(string username, string password)
    {
        var user = ctx.Users.SingleOrDefault(u => u.UserName == username);
        if (user == null) return null;
        var result = await signInManager.PasswordSignInAsync(user, password, true, false);
        return result.Succeeded ?  user.UserName : null;
    }
}