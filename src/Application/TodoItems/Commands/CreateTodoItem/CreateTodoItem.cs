using UserService.Application.Common.Interfaces;
using UserService.Domain.Entities;
using UserService.Domain.Events;

namespace UserService.Application.TodoItems.Commands.CreateTodoItem;

public record CreateTodoItemCommand : IRequest<int>
{
    public int ListId { get; init; }

    public string? Title { get; init; }
}

public class CreateTodoItemCommandHandler : IRequestHandler<CreateTodoItemCommand, int>
{
    public CreateTodoItemCommandHandler()
    {
    }

    public Task<int> Handle(CreateTodoItemCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
