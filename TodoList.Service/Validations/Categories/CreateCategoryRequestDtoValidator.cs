using FluentValidation;
using TodoList.Models.Dtos.Category.RequestDtos;

namespace TodoList.Service.Validations.Categories;

public class CreateCategoryRequestDtoValidator : AbstractValidator<CreateCategoryRequestDto>
{
    public CreateCategoryRequestDtoValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MinimumLength(3);
    }
}
