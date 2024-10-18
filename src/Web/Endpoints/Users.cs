using UserService.Infrastructure.Identity;

namespace UserService.Web.Endpoints;

public class Users : IEndpointGroupBase
{
    public void Map(WebApplication app)
    {
        app.MapGroup(this)
            .MapIdentityApi<ApplicationUser>();
    }
}
