using UserService.Application.Common.Interfaces;
using UserService.Domain.Entities;
using UserService.Domain.Enums;

namespace UserService.Application.TodoItems.Commands.UpdateTodoItemDetail;

public record UpdateTodoItemDetailCommand : IRequest
{
    public int Id { get; init; }

    public int ListId { get; init; }

    public PriorityLevel Priority { get; init; }

    public string? Note { get; init; }
}

public class UpdateTodoItemDetailCommandHandler : IRequestHandler<UpdateTodoItemDetailCommand>
{

    public UpdateTodoItemDetailCommandHandler()
    {
    }

    public Task Handle(UpdateTodoItemDetailCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
