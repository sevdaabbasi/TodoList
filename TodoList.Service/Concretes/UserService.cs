using AutoMapper;
using Core.Results;
using Microsoft.AspNetCore.Identity;
using TodoList.Models.Dtos.User.ResponseDtos;
using TodoList.Models.Models;
using TodoList.Service.Rules;
using TodoList.Service.Services.Abstracts;

namespace TodoList.Service.Services.Concretes;

public class UserService : IUserService
{
    private readonly UserManager<User> _userManager;
    private readonly IMapper _mapper;
    private readonly UserBusinessRules _businessRules;

    public UserService(UserManager<User> userManager, IMapper mapper, UserBusinessRules businessRules)
    {
        _userManager = userManager;
        _mapper = mapper;
        _businessRules = businessRules;
    }

    public async Task<Result<List<UserResponseDto>>> GetAllAsync()
    {
        List<User> users = _userManager.Users.ToList();
        List<UserResponseDto> response = _mapper.Map<List<UserResponseDto>>(users);

        return ResultFactory.Success(
            response,
            statusCode: System.Net.HttpStatusCode.OK);
    }

    public async Task<Result<UserResponseDto>> GetByIdAsync(string id)
    {
        await _businessRules.UserShouldExistWhenRequestedAsync(id);
        User? user = await _userManager.FindByIdAsync(id);
        UserResponseDto response = _mapper.Map<UserResponseDto>(user);

        return ResultFactory.Success(
            response,
            statusCode: System.Net.HttpStatusCode.OK);
    }
}
