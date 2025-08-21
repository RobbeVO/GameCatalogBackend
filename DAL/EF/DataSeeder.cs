using GameCatalog.BL.domain;
using Microsoft.AspNetCore.Identity;

namespace GameCatalog.DAL.EF;

public static class DataSeeder
{
    public static void Seed(GcDbContext ctx)
    {
        // fetch existing accounts
        var a1 = new Account
        {
            Identity = ctx.Users.SingleOrDefault(u => u.Email == "van.osselaer.robbe@hotmail.com")
        };
        var a2 = new Account
        {
            Identity = ctx.Users.SingleOrDefault(u => u.Email == "filip.slaets@outlook.com")
        };

        // --- Games ---
        var g1 = new Game
        {
            Name = "Hollow Knight",
            Description =
                "Forge your own path in Hollow Knight! An epic action adventure through a vast, ruined kingdom of insects and heroes.",
            ImageUrl =
                "https://static.wikia.nocookie.net/hollowknight/images/e/e6/Hollow_Knight_VoidHeart_Edition_Xbox_One_Front_Cover.jpg/revision/latest/scale-to-width-down/1200?cb=20201215192046",
            Genres = new List<Genre>
                { Genre.Adventure, Genre.Metroidvania, Genre.Singleplayer, Genre.Story, Genre.TwoDPlatformer }
        };

        var g2 = new Game
        {
            Name = "The Legend of Zelda: Breath of the Wild",
            Description =
                "Step into a world of discovery, exploration, and adventure in The Legend of Zelda: Breath of the Wild.",
            ImageUrl = "https://upload.wikimedia.org/wikipedia/en/0/0e/The_Legend_of_Zelda_Breath_of_the_Wild.jpg",
            Genres = new List<Genre> { Genre.Adventure, Genre.Story, Genre.FreeRoam, Genre.Singleplayer }
        };

        var g3 = new Game
        {
            Name = "Super Smash Bros. Ultimate",
            Description =
                "Battle it out in the biggest crossover fighting game ever with over 70 characters from across gaming history.",
            ImageUrl = "https://upload.wikimedia.org/wikipedia/en/5/50/Super_Smash_Bros._Ultimate.jpg",
            Genres = new List<Genre> { Genre.Fighting, Genre.PlatformFighter, Genre.Multiplayer, Genre.Party }
        };

        var g4 = new Game
        {
            Name = "Elden Ring",
            Description =
                "A vast action RPG developed by FromSoftware in collaboration with George R. R. Martin, featuring open-world exploration and challenging combat.",
            ImageUrl = "https://upload.wikimedia.org/wikipedia/en/b/b9/Elden_Ring_Box_art.jpg",
            Genres = new List<Genre> { Genre.RPG, Genre.Adventure, Genre.Story, Genre.FreeRoam, Genre.Singleplayer }
        };

        var g5 = new Game
        {
            Name = "Among Us",
            Description =
                "A social deduction multiplayer game where crewmates work together while impostors try to sabotage and eliminate them.",
            ImageUrl = "https://upload.wikimedia.org/wikipedia/en/f/f9/Among_Us_cover_art.jpg",
            Genres = new List<Genre> { Genre.SocialDeduction, Genre.Multiplayer, Genre.Party }
        };

        var g6 = new Game
        {
            Name = "Minecraft",
            Description =
                "A sandbox game where players can build, explore, and survive in procedurally generated worlds made of blocks.",
            ImageUrl = "https://upload.wikimedia.org/wikipedia/en/5/51/Minecraft_cover.png",
            Genres = new List<Genre>
                { Genre.Sandbox, Genre.Simulation, Genre.FreeRoam, Genre.Multiplayer, Genre.Singleplayer }
        };

        var g7 = new Game
        {
            Name = "Mario Kart 8 Deluxe",
            Description =
                "Nintendo's flagship kart racing game featuring iconic characters, crazy tracks, and frantic multiplayer fun.",
            ImageUrl = "https://upload.wikimedia.org/wikipedia/en/0/0d/Mario_Kart_8_Deluxe.jpg",
            Genres = new List<Genre> { Genre.Racing, Genre.Party, Genre.Multiplayer }
        };

        var g8 = new Game
        {
            Name = "Shadow of the Colossus",
            Description =
                "Journey through a mysterious land and defeat massive colossi in a minimalist but powerful adventure.",
            ImageUrl = "https://upload.wikimedia.org/wikipedia/en/8/89/Shadow_of_the_Colossus.jpg",
            Genres = new List<Genre> { Genre.Adventure, Genre.Singleplayer }
        };

        var g9 = new Game
        {
            Name = "Super Mario Odyssey",
            Description = "Mario embarks on a globe-trotting 3D platforming adventure to rescue Princess Peach.",
            ImageUrl = "https://upload.wikimedia.org/wikipedia/en/8/8d/Super_Mario_Odyssey.jpg",
            Genres = new List<Genre> { Genre.Adventure, Genre.ThreeDPlatformer, Genre.Collectathon }
        };

        var g10 = new Game
        {
            Name = "Detroit: Become Human",
            Description =
                "A branching narrative game where choices determine the fates of androids in a futuristic Detroit.",
            ImageUrl = "https://upload.wikimedia.org/wikipedia/en/8/8e/Detroit_Become_Human.jpg",
            Genres = new List<Genre> { Genre.Story, Genre.ChooseYourOwnAdventure, Genre.Singleplayer }
        };

        var g11 = new Game
        {
            Name = "Disco Elysium",
            Description = "A groundbreaking RPG focused almost entirely on story, dialogue, and player choices.",
            ImageUrl = "https://upload.wikimedia.org/wikipedia/en/6/60/Disco_Elysium_cover_art.png",
            Genres = new List<Genre> { Genre.Story, Genre.RPG, Genre.Singleplayer }
        };

        var g12 = new Game
        {
            Name = "God of War (2018)",
            Description =
                "Kratos and Atreus journey across Norse mythology in this epic story-driven action-adventure.",
            ImageUrl = "https://upload.wikimedia.org/wikipedia/en/a/a7/God_of_War_4_cover.jpg",
            Genres = new List<Genre> { Genre.Adventure, Genre.Story, Genre.Singleplayer, Genre.RPG }
        };

        var g13 = new Game
        {
            Name = "Red Dead Redemption 2",
            Description =
                "An epic tale of life in America at the dawn of the modern age. Adventure and story blend seamlessly in its vast open world.",
            ImageUrl = "https://upload.wikimedia.org/wikipedia/en/4/44/Red_Dead_Redemption_II.jpg",
            Genres = new List<Genre> { Genre.Adventure, Genre.Story, Genre.FreeRoam, Genre.RPG, Genre.Singleplayer }
        };

        var g14 = new Game
        {
            Name = "Fortnite",
            Description =
                "A massively popular online battle royale where players fight to be the last one standing, build structures, and compete in fast-paced matches.",
            ImageUrl = "https://upload.wikimedia.org/wikipedia/en/0/09/Fortnite_cover_art.jpg",
            Genres = new List<Genre> { Genre.BattleRoyale, Genre.Multiplayer, Genre.ThirdPersonShooter, Genre.Sandbox }
        };

        var g15 = new Game
        {
            Name = "Rocket League",
            Description = "High-powered vehicles meet soccer in this fast-paced multiplayer game where players compete in teams to score goals using rocket-powered cars.",
            ImageUrl = "https://upload.wikimedia.org/wikipedia/en/e/e0/Rocket_League_coverart.jpg",
            Genres = new List<Genre> 
            { 
                Genre.Sports, 
                Genre.Multiplayer 
            }
        };

        var g16 = new Game
        {
            Name = "League of Legends",
            Description = "One of the world’s most popular MOBAs where players compete in 5v5 matches, aiming to destroy the enemy nexus with strategic teamwork.",
            ImageUrl = "https://upload.wikimedia.org/wikipedia/en/f/f2/LoL_Cover.jpg",
            Genres = new List<Genre> 
            { 
                Genre.Multiplayer, 
                Genre.RPG,
                Genre.Fighting
            }
        };

        var g17 = new Game
        {
            Name = "Overwatch",
            Description = "A team-based hero shooter where players select unique heroes and compete in objective-based game modes.",
            ImageUrl = "https://upload.wikimedia.org/wikipedia/en/5/51/Overwatch_cover_art.jpg",
            Genres = new List<Genre> 
            { 
                Genre.HeroShooter, 
                Genre.Multiplayer, 
                Genre.FirstPersonShooter 
            }
        };

        var g18 = new Game
        {
            Name = "Call of Duty: Warzone",
            Description =
                "A free-to-play battle royale experience with fast-paced gunplay, vehicles, and squad-based action.",
            ImageUrl = "https://upload.wikimedia.org/wikipedia/en/5/52/Call_of_Duty_Warzone_cover.jpg",
            Genres = new List<Genre>
            {
                Genre.FirstPersonShooter,
                Genre.BattleRoyale,
                Genre.Multiplayer
            }
        };
        
        var g19 = new Game
        {
            Name = "Jackbox Party Pack",
            Description = "A collection of party games where players join via their phones. Great for online group fun with trivia, drawing, and chaos!",
            ImageUrl = "https://upload.wikimedia.org/wikipedia/en/8/87/Jackbox_Party_Pack_Logo.png",
            Genres = new List<Genre>
            {
                Genre.Party,
            }
        };

        // --- Reviews ---
        var r1 = new Review
        {
            Account = a1,
            Game = g1,
            Rating = 5,
            Title = "Masterful storytelling",
            Content = "At the start I had some trouble getting into the game, but once I got into it the story really got to me. By the end I couldn't help but clap while crying."
        };

        var r2 = new Review
        {
            Account = a2,
            Game = g2,
            Rating = 5,
            Title = "A masterpiece",
            Content = "Breath of the Wild redefined open world design. The sense of discovery is unmatched."
        };

        var r3 = new Review
        {
            Account = a1,
            Game = g3,
            Rating = 4,
            Title = "Endless fun with friends",
            Content = "Smash Ultimate is chaotic in the best way. Balancing could be better but nothing beats the roster."
        };

        var r4 = new Review
        {
            Account = a2,
            Game = g4,
            Rating = 5,
            Title = "Dark Souls perfected",
            Content = "Challenging but fair, with an amazing world to explore. My game of the decade."
        };

        var r5 = new Review
        {
            Account = a1,
            Game = g5,
            Rating = 3,
            Title = "Fun with the right people",
            Content = "Among Us is only as good as your group of friends. Great for parties, not much else."
        };

        var r6 = new Review
        {
            Account = a2,
            Game = g6,
            Rating = 5,
            Title = "Infinite creativity",
            Content = "Minecraft never gets old. I can build, explore, or just relax. It's the ultimate sandbox."
        };

        var r7 = new Review
        {
            Account = a1,
            Game = g7,
            Rating = 4,
            Title = "The ultimate party racer",
            Content = "Mario Kart 8 Deluxe is pure fun. Still, the blue shell is the bane of my existence."
        };

        var r8 = new Review
        {
            Account = a1,
            Game = g14,
            Rating = 3,
            Title = "Fun but flawed",
            Content = "Fortnite can be a blast with friends, and the constant updates keep things fresh. That said, the game feels unbalanced at times, especially with new weapons being added too often. The building mechanics, while unique, can be frustrating for casual players who get steamrolled by people instantly constructing skyscrapers mid-fight. It’s enjoyable, but also very chaotic and not always fair."
        };

        a1.Reviews = new List<Review> { r1, r3, r5, r7, r8 };
        a2.Reviews = new List<Review> { r2, r4, r6 };
        
        g1.Reviews = new List<Review> { r1 };
        g2.Reviews = new List<Review> { r2 };
        g3.Reviews = new List<Review> { r3 };
        g4.Reviews = new List<Review> { r4 };
        g5.Reviews = new List<Review> { r5 };
        g6.Reviews = new List<Review> { r6 };
        g7.Reviews = new List<Review> { r7 };
        g14.Reviews = new List<Review> { r8 };

        ctx.Games.AddRange(g1, g2, g3, g4, g5, g6, g7, g8, g9, g10, g11, g12, g13, g14, g15, g16, g17, g18, g19);
        ctx.Accounts.AddRange(a1, a2);
        ctx.Reviews.AddRange(r1, r2, r3, r4, r5, r6, r7, r8);

        ctx.SaveChanges();
    }
}