using Core.Results;
using TodoList.Models.Dtos.User.RequestDtos;
using TodoList.Models.Dtos.User.ResponseDtos;

namespace TodoList.Service.Services.Abstracts;

public interface IAuthService
{
    Task<Result<UserResponseDto>> RegisterAsync(RegisterRequestDto dto);
    Task<Result<UserResponseDto>> CreateAdminAsync(RegisterRequestDto dto);
    Task<Result<UserResponseDto>> LoginAsync(LoginRequestDto dto);
    Task<Result> LogoutAsync();
}
