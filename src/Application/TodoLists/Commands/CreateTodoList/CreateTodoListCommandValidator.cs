using UserService.Application.Common.Interfaces;

namespace UserService.Application.TodoLists.Commands.CreateTodoList;

public class CreateTodoListCommandValidator : AbstractValidator<CreateTodoListCommand>
{
    public CreateTodoListCommandValidator()
    {
        RuleFor(v => v.Title)
            .NotEmpty()
            .MaximumLength(200)
            .WithMessage("'{PropertyName}' must be unique.")
            .WithErrorCode("Unique");
    }
}
