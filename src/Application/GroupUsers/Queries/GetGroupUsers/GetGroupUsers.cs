using UserService.Application.Common.Interfaces;

namespace UserService.Application.GroupUsers.Queries.GetGroupUsers;

public record GetGroupUsersQuery : IRequest<string>
{
}

public class GetGroupUsersQueryValidator : AbstractValidator<GetGroupUsersQuery>
{
}

public class GetGroupUsersQueryHandler : IRequestHandler<GetGroupUsersQuery, string>
{
    private readonly IApplicationDbContext _context;

    public GetGroupUsersQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public Task<string> Handle(GetGroupUsersQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
