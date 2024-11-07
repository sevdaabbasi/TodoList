using Core.Results;
using TodoList.Models.Dtos.Todo.RequestDtos;
using TodoList.Models.Dtos.Todo.ResponseDtos;

namespace TodoList.Service.Services.Abstracts;

public interface ITodoService
{
    Result<TodoResponseDto> Create(CreateTodoRequestDto dto);
    Result<TodoResponseDto> Update(int id, UpdateTodoRequestDto dto);
    Result<TodoResponseDto> Delete(int id);
    Result<List<TodoResponseDto>> GetAll();
    Result<List<TodoResponseDto>> GetAllByUserEmail(string email);
    Result<TodoResponseDto> GetById(int id);
}
