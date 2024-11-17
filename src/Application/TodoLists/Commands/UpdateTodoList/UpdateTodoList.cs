using UserService.Application.Common.Interfaces;
using UserService.Domain.Entities;

namespace UserService.Application.TodoLists.Commands.UpdateTodoList;

public record UpdateTodoListCommand : IRequest
{
    public int Id { get; init; }

    public string? Title { get; init; }
}

public class UpdateTodoListCommandHandler : IRequestHandler<UpdateTodoListCommand>
{

    public UpdateTodoListCommandHandler()
    {
    }

    public Task Handle(UpdateTodoListCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
