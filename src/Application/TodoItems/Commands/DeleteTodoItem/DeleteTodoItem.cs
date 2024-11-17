using UserService.Application.Common.Interfaces;
using UserService.Domain.Entities;
using UserService.Domain.Events;

namespace UserService.Application.TodoItems.Commands.DeleteTodoItem;

public record DeleteTodoItemCommand(int Id) : IRequest;

public class DeleteTodoItemCommandHandler : IRequestHandler<DeleteTodoItemCommand>
{

    public DeleteTodoItemCommandHandler()
    {
    }

    public Task Handle(DeleteTodoItemCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
