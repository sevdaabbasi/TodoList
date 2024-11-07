using AutoMapper;
using TodoList.Models.Dtos.Category.RequestDtos;
using TodoList.Models.Dtos.Category.ResponseDtos;
using TodoList.Models.Dtos.Todo.RequestDtos;
using TodoList.Models.Dtos.Todo.ResponseDtos;
using TodoList.Models.Dtos.User.RequestDtos;
using TodoList.Models.Dtos.User.ResponseDtos;
using TodoList.Models.Models;

namespace TodoList.Service.Mapping;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        
        CreateMap<CreateTodoRequestDto, Todo>().ReverseMap();
        CreateMap<UpdateTodoRequestDto, Todo>().ReverseMap();
        CreateMap<Todo, TodoResponseDto>();

        // Category
        CreateMap<CreateCategoryRequestDto, Category>().ReverseMap();
        CreateMap<UpdateCategoryRequestDto, Category>().ReverseMap();
        CreateMap<Category, CategoryResponseDto>();

        // User 
        CreateMap<RegisterRequestDto, User>().ReverseMap();
        CreateMap<User, UserResponseDto>();
    }
}
