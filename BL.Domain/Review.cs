using System.ComponentModel.DataAnnotations;

namespace GameCatalog.BL.domain;

public class Review
{
    [Key]
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public int Rating { get; set; }
    
    public Account Account { get; set; }
    public Game Game { get; set; }
}