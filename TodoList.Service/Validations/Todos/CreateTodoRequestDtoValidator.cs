using FluentValidation;
using TodoList.Models.Dtos.Todo.RequestDtos;

namespace TodoList.Service.Validations.Todos;

public class CreateTodoRequestDtoValidator : AbstractValidator<CreateTodoRequestDto>
{
    public CreateTodoRequestDtoValidator()
    {
        RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık boş olamaz");
        RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama boş olamaz");
        RuleFor(x => x.StartDate).LessThan(x => x.EndDate).WithMessage("Başlangıç tarihi bitiş tarihinden önce olmalıdır");
        RuleFor(x => x.EndDate).NotEmpty();
        RuleFor(x => x.CategoryId).NotEmpty();
        RuleFor(x => x.UserId).NotEmpty();
    }
}
