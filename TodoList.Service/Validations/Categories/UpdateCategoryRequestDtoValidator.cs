
using FluentValidation;
using TodoList.Models.Dtos.Category.RequestDtos;

namespace TodoList.Service.Validations.Categories;

public class UpdateCategoryRequestDtoValidator : AbstractValidator<UpdateCategoryRequestDto>
{
    public UpdateCategoryRequestDtoValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
    }
}
