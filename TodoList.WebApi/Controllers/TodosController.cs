using Microsoft.AspNetCore.Mvc;
using TodoList.Models.Dtos.Todo.RequestDtos;
using TodoList.Service.Services.Abstracts;

namespace TodoList.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TodosController : ControllerBase
{
    private readonly ITodoService _todoService;

    public TodosController(ITodoService todoService)
    {
        _todoService = todoService;
    }

    [HttpPost]
    public IActionResult Create([FromBody] CreateTodoRequestDto dto)
    {
        var result = _todoService.Create(dto);
        return Ok(result);
    }

    [HttpPut("{id:int}")]
    public IActionResult Update(int id, [FromBody] UpdateTodoRequestDto dto)
    {
        var result = _todoService.Update(id, dto);
        if (!result.IsSuccess) return BadRequest(result);
        return Ok(result);
    }

    [HttpDelete("{id:int}")]
    public IActionResult Delete([FromRoute] int id)
    {
        var result = _todoService.Delete(id);
        if (!result.IsSuccess) return BadRequest(result);
        return Ok(result);
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var result = _todoService.GetAll();
        return Ok(result);
    }

    [HttpGet("{email}/todos")]
    public IActionResult GetAllByUserEmail([FromRoute] string email)
    {
        var result = _todoService.GetAllByUserEmail(email);
        return Ok(result);
    }

    [HttpGet("todos/{id:int}")]
    public IActionResult GetById([FromRoute] int id)
    {
        var result = _todoService.GetById(id);
        if (!result.IsSuccess) return BadRequest(result);
        return Ok(result);
    }
}
