using Core.Results;
using TodoList.Models.Dtos.User.ResponseDtos;

namespace TodoList.Service.Services.Abstracts;

public interface IUserService
{
    Task<Result<List<UserResponseDto>>> GetAllAsync();
    Task<Result<UserResponseDto>> GetByIdAsync(string id);
}
