using System.ComponentModel.DataAnnotations;

namespace GameCatalog.BL.domain;

public class Game
{
    [Key]
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public IEnumerable<Genre> Genres { get; set; }
    public IEnumerable<Review> Reviews { get; set; }
}