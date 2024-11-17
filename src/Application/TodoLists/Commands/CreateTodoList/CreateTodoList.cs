using UserService.Application.Common.Interfaces;
using UserService.Domain.Entities;

namespace UserService.Application.TodoLists.Commands.CreateTodoList;

public record CreateTodoListCommand : IRequest<int>
{
    public string? Title { get; init; }
}

public class CreateTodoListCommandHandler : IRequestHandler<CreateTodoListCommand, int>
{

    public CreateTodoListCommandHandler()
    {
    }

    public Task<int> Handle(CreateTodoListCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
