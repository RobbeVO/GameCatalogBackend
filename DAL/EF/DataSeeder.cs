using GameCatalog.BL.domain;
using Microsoft.AspNetCore.Identity;

namespace GameCatalog.DAL.EF;

public static class DataSeeder
{
    public static void Seed(GcDbContext ctx)
    {
        var g1 = new Game { Description = "Forge your own path in Hollow Knight! An epic action adventure through a vast," +
                                          " ruined kingdom of insects and heroes. Hollow Knight is a classically styled" +
                                          " 2D action adventure across a vast interconnected world.",
            Name = "Hollow Knight",
            ImageUrl = "https://static.wikia.nocookie.net/hollowknight/images/e/e6/Hollow_Knight_VoidHeart_Edition_Xbox_One_Front_Cover.jpg/revision/latest/scale-to-width-down/1200?cb=20201215192046",
            Genres = new List<Genre> { Genre.Adventure, Genre.Metroidvania, Genre.Singleplayer, Genre.Story, Genre.TwoDPlatformer }
        };
        
        var a1 = new Account
        {
            Identity = ctx.Users.SingleOrDefault(u => u.Email == "van.osselaer.robbe@hotmail.com")
        };
        var a2 = new Account
        {
            Identity = ctx.Users.SingleOrDefault(u => u.Email == "filip.slaets@outlook.com")
        };

        var r1 = new Review { Account = a1, Game = g1, Rating = 5, Title = "Masterful storytelling", 
            Content = "At the start I had some trouble getting into the game. I got lost very easily and well the crossroads" +
                      "aren't particularly appealing but once I got into it the story of this fallen kingdom and the few" +
                      "remaining inhabitants really got to me. By the end I couldn't help but stand up from my chair and clap while crying."};
        
        a1.Reviews = [r1];
        g1.Reviews = [r1];
        
        ctx.Games.AddRange(g1);
        ctx.Accounts.AddRange(a1, a2);
        ctx.Reviews.AddRange(r1);

        ctx.SaveChanges();
    }
}