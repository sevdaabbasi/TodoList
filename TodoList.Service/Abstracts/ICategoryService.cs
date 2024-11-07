using Core.Results;
using TodoList.Models.Dtos.Category.RequestDtos;
using TodoList.Models.Dtos.Category.ResponseDtos;

namespace TodoList.Service.Services.Abstracts;

public interface ICategoryService
{
    Result<CategoryResponseDto> Create(CreateCategoryRequestDto dto);
    Result<CategoryResponseDto> Update(int id, UpdateCategoryRequestDto dto);
    Result<CategoryResponseDto> Delete(int id);
    Result<List<CategoryResponseDto>> GetAll();
    Result<CategoryResponseDto> GetById(int id);
}
