using UserService.Application.Common.Interfaces;
using UserService.Domain.Entities;

namespace UserService.Application.TodoLists.Commands.DeleteTodoList;

public record DeleteTodoListCommand(int Id) : IRequest;

public class DeleteTodoListCommandHandler : IRequestHandler<DeleteTodoListCommand>
{
    public DeleteTodoListCommandHandler()
    {
    }

    public Task Handle(DeleteTodoListCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
