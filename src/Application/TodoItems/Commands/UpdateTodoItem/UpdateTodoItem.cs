using UserService.Application.Common.Interfaces;
using UserService.Domain.Entities;

namespace UserService.Application.TodoItems.Commands.UpdateTodoItem;

public record UpdateTodoItemCommand : IRequest
{
    public int Id { get; init; }

    public string? Title { get; init; }

    public bool Done { get; init; }
}

public class UpdateTodoItemCommandHandler : IRequestHandler<UpdateTodoItemCommand>
{

    public UpdateTodoItemCommandHandler()
    {
    }

    public Task Handle(UpdateTodoItemCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
