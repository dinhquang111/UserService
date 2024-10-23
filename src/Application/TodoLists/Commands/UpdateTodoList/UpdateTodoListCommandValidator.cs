using UserService.Application.Common.Interfaces;

namespace UserService.Application.TodoLists.Commands.UpdateTodoList;

public class UpdateTodoListCommandValidator : AbstractValidator<UpdateTodoListCommand>
{
    public UpdateTodoListCommandValidator()
    {
        RuleFor(v => v.Title)
            .NotEmpty()
            .MaximumLength(200)
            .WithMessage("'{PropertyName}' must be unique.")
            .WithErrorCode("Unique");
    }
}
