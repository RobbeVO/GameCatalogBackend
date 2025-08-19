using GameCatalog.BL.domain;
using Microsoft.AspNetCore.Identity;

namespace GameCatalog.DAL.EF;

public static class DataSeeder
{
    public static void Seed(GcDbContext context)
    {
        var g1 = new Game { Description = "Forge your own path in Hollow Knight! An epic action adventure through a vast," +
                                          " ruined kingdom of insects and heroes. Hollow Knight is a classically styled" +
                                          " 2D action adventure across a vast interconnected world.",
            Name = "Hollow Knight",
            Genres = new List<Genre> { Genre.Adventure, Genre.Metroidvania, Genre.Singleplayer, Genre.Story, Genre.TwoDPlatformer }
        };

        var iu1 = new IdentityUser { Email = "van.osselaer.robbe@hotmail.com", UserName = "RobbeVO"};

        var a1 = new Account {  };
        
        context.Games.AddRange(g1);
    }
}