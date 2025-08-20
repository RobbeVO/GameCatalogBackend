using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace GameCatalog.BL.domain;

public class Account
{
    [Key]
    public Guid Id { get; set; }
    
    public IdentityUser Identity { get; set; }
    public IEnumerable<Review> Reviews { get; set; }
}