﻿using UserService.Application.Common.Interfaces;
using UserService.Application.Common.Mappings;
using UserService.Application.Common.Models;

namespace UserService.Application.TodoItems.Queries.GetTodoItemsWithPagination;

public record GetTodoItemsWithPaginationQuery : IRequest<PaginatedList<TodoItemBriefDto>>
{
    public int ListId { get; init; }
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class
    GetTodoItemsWithPaginationQueryHandler : IRequestHandler<GetTodoItemsWithPaginationQuery,
    PaginatedList<TodoItemBriefDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetTodoItemsWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<TodoItemBriefDto>> Handle(GetTodoItemsWithPaginationQuery request,
        CancellationToken cancellationToken)
    {
        return await Task.FromResult(new PaginatedList<TodoItemBriefDto>(new List<TodoItemBriefDto>(), 0, 1, 10));
        // return await _context.TodoItems
        //     .Where(x => x.ListId == request.ListId)
        //     .OrderBy(x => x.Title)
        //     .ProjectTo<TodoItemBriefDto>(_mapper.ConfigurationProvider)
        //     .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}
