using Microsoft.AspNetCore.Identity;

namespace GameCatalog.BL.domain;

public class Account
{
    public Guid Id { get; set; }
    
    public IdentityUser Identity { get; set; }
    public IEnumerable<Review> Reviews { get; set; }
}