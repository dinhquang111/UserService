using UserService.Application.Common.Interfaces;
using UserService.Application.Common.Security;
using UserService.Domain.Constants;

namespace UserService.Application.TodoLists.Commands.PurgeTodoLists;

[Authorize(Roles = Roles.Administrator)]
[Authorize(Policy = Policies.CanPurge)]
public record PurgeTodoListsCommand : IRequest;

public class PurgeTodoListsCommandHandler : IRequestHandler<PurgeTodoListsCommand>
{

    public PurgeTodoListsCommandHandler()
    {
    }

    public Task Handle(PurgeTodoListsCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
