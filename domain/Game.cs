namespace BL.domain;

public class Game
{
    public string Name { get; set; }
    public string Description { get; set; }
    public IEnumerable<Genre> Genres { get; set; }
    public IEnumerable<Review> Reviews { get; set; }
}