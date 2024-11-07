using AutoMapper;
using Core.Results;
using Microsoft.AspNetCore.Identity;
using TodoList.Models.Dtos.User.RequestDtos;
using TodoList.Models.Dtos.User.ResponseDtos;
using TodoList.Models.Models;
using TodoList.Service.Services.Abstracts;

namespace TodoList.Service.Services.Concretes;

public class AuthService : IAuthService
{
	private readonly UserManager<User> _userManager;
	private readonly SignInManager<User> _signInManager;
	private readonly IMapper _mapper;

	public AuthService(UserManager<User> userManager, SignInManager<User> signInManager, IMapper mapper)
	{
		_userManager = userManager;
		_signInManager = signInManager;
		_mapper = mapper;
	}

	public async Task<Result<UserResponseDto>> LoginAsync(LoginRequestDto dto)
	{
		User? user = await _userManager.FindByEmailAsync(dto.Email);
		bool isPasswordValid = await _userManager.CheckPasswordAsync(user, dto.Password);

		if (user is null || !isPasswordValid) return ResultFactory.Failure<UserResponseDto>(
			null,
			statusCode: System.Net.HttpStatusCode.Unauthorized,
			message: "Invalid Email Or Password.");

		await _signInManager.SignInAsync(user, isPasswordValid);

		UserResponseDto response = _mapper.Map<UserResponseDto>(user);

		return ResultFactory.Success(
			response,
			statusCode: System.Net.HttpStatusCode.OK);
	}

	public async Task<Result> LogoutAsync()
	{
		await _signInManager.SignOutAsync();
		return ResultFactory.Success(
			statusCode: System.Net.HttpStatusCode.OK,
			message: "Logout Success.");
	}

	public async Task<Result<UserResponseDto>> RegisterAsync(RegisterRequestDto dto)
	{
		User mapped = _mapper.Map<User>(dto);

		var created = await _userManager.CreateAsync(mapped, dto.Password);
		await _userManager.AddToRoleAsync(mapped, "User");

		UserResponseDto response = _mapper.Map<UserResponseDto>(mapped);

		if (created.Succeeded) return ResultFactory.Success(
			response,
			statusCode: System.Net.HttpStatusCode.OK);

		return ResultFactory.Failure<UserResponseDto>(
			null,
			statusCode: System.Net.HttpStatusCode.BadRequest,
			message: string.Join(", ", created.Errors.Select(e => e.Description)));
	}

	public async Task<Result<UserResponseDto>> CreateAdminAsync(RegisterRequestDto dto)
	{
		User mapped = _mapper.Map<User>(dto);

		var created = await _userManager.CreateAsync(mapped, dto.Password);
		await _userManager.AddToRoleAsync(mapped, "Admin");

		UserResponseDto response = _mapper.Map<UserResponseDto>(mapped);

		if (created.Succeeded) return ResultFactory.Success(
			response,
			statusCode: System.Net.HttpStatusCode.OK);

		return ResultFactory.Failure<UserResponseDto>(
			null,
			statusCode: System.Net.HttpStatusCode.BadRequest,
			message: string.Join(", ", created.Errors.Select(e => e.Description)));
	}
}
