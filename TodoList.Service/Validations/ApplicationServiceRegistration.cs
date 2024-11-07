using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using TodoList.Models.Dtos.Category.RequestDtos;
using TodoList.Models.Dtos.Todo.RequestDtos;
using TodoList.Service.Rules;
using TodoList.Service.Services.Abstracts;
using TodoList.Service.Services.Concretes;
using TodoList.Service.Validations.Categories;
using TodoList.Service.Validations.Todos;

namespace TodoList.Service.Validations;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<ITodoService, TodoService>();

        services.AddScoped<UserBusinessRules>();
        services.AddScoped<CategoryBusinessRules>();
        services.AddScoped<TodoBusinessRules>();

        services.AddScoped<IValidator<CreateCategoryRequestDto>, CreateCategoryRequestDtoValidator>();
        services.AddScoped<IValidator<UpdateCategoryRequestDto>, UpdateCategoryRequestDtoValidator>();
        services.AddScoped<IValidator<CreateTodoRequestDto>, CreateTodoRequestDtoValidator>();
        services.AddScoped<IValidator<UpdateTodoRequestDto>, UpdateTodoRequestDtoValidator>();

        return services;
    }
}