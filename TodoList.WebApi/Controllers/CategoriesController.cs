using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TodoList.Models.Dtos.Category.RequestDtos;
using TodoList.Service.Services.Abstracts;

namespace TodoList.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoriesController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public IActionResult Create([FromBody] CreateCategoryRequestDto dto)
    {
        var result = _categoryService.Create(dto);
        return Ok(result);
    }

    [HttpPut("{id:int}")]
    [Authorize(Roles = "Admin")]
    public IActionResult Update(int id, [FromBody] UpdateCategoryRequestDto dto)
    {
        var result = _categoryService.Update(id, dto);
        if (!result.IsSuccess) return BadRequest(result);
        return Ok(result);
    }

    [HttpDelete("{id:int}")]
    [Authorize(Roles = "Admin")]
    public IActionResult Delete([FromRoute] int id)
    {
        var result = _categoryService.Delete(id);
        if (!result.IsSuccess) return BadRequest(result);
        return Ok(result);
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var result = _categoryService.GetAll();
        return Ok(result);
    }

    [HttpGet("{id:int}")]
    public IActionResult GetById([FromRoute] int id)
    {
        var result = _categoryService.GetById(id);
        if (!result.IsSuccess) return BadRequest(result);
        return Ok(result);
    }
}
