namespace BL.domain;

public class Game
{
    //something's off
    public string Name { get; set; }
    public string Description { get; set; }
    public IEnumerable<Genre> Genres { get; set; }
    public IEnumerable<Review> Reviews { get; set; }
}