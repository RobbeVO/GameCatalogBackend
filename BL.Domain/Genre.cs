using System.ComponentModel;

namespace GameCatalog.BL.domain;

public enum Genre
{
    Party,
    RPG,
    MMORPG,
    [Description("2D Platformer")]TwoDPlatformer,
    [Description("3D Platformer")]ThreeDPlatformer,
    Racing,
    [Description("Beat-em-up")]BeatEmUp,
    [Description("Platform Fighter")]PlatformFighter,
    Collectathon,
    Sports,
    Adventure,
    Sandbox,
    Simulation,
    Story,
    Freeroam,
    Metroidvania,
    [Description("Battle Royale")]BattleRoyale,
    [Description("First Person Shooter")]FirstPersonShooter,
    [Description("Third Person Shooter")]ThirdPersonShooter,
    Survival,
    Horror,
    [Description("Choose Your Own Adventure")]ChooseYourOwnAdventure,
    SciFi,
    Fighting,
    [Description("Side Scroller")]SideScroller,
    [Description("Hero Shooter")]HeroShooter,
    [Description("Social Deduction")]SocialDeduction,
    Puzzle,
    [Description("Time Management")]TimeManagement,
    Multiplayer,
    Singleplayer
}