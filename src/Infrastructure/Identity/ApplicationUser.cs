using Microsoft.AspNetCore.Identity;

namespace UserService.Infrastructure.Identity;

public class ApplicationUser : IdentityUser
{
    public override string? Email { get; set; }
}
