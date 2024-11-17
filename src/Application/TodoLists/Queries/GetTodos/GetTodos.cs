using UserService.Application.Common.Security;

namespace UserService.Application.TodoLists.Queries.GetTodos;

[Authorize]
public record GetTodosQuery : IRequest<TodosVm>;

public class GetTodosQueryHandler : IRequestHandler<GetTodosQuery, TodosVm>
{
    private readonly IMapper _mapper;

    public GetTodosQueryHandler(IMapper mapper)
    {
        _mapper = mapper;
    }

    public Task<TodosVm> Handle(GetTodosQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
