using System.Reflection;

namespace UserService.Api.Infrastructure;

public static class WebApplicationExtensions
{
    public static RouteGroupBuilder MapGroup(this WebApplication app, IEndpointGroupBase group)
    {
        string groupName = group.GetType().Name;

        return app
            .MapGroup($"/api/{groupName}")
            .WithGroupName(groupName)
            .WithTags(groupName)
            .WithOpenApi();
    }

    public static WebApplication MapEndpoints(this WebApplication app)
    {
        Type endpointGroupType = typeof(IEndpointGroupBase);

        Assembly assembly = Assembly.GetExecutingAssembly();

        IEnumerable<Type> endpointGroupTypes = assembly.GetExportedTypes()
            .Where(t => endpointGroupType.IsAssignableFrom(t) && t is { IsInterface: false, IsAbstract: false });

        foreach (Type type in endpointGroupTypes)
        {
            if (Activator.CreateInstance(type) is IEndpointGroupBase instance)
            {
                instance.Map(app);
            }
        }

        return app;
    }
}
