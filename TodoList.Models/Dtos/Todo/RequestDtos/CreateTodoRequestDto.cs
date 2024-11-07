namespace TodoList.Models.Dtos.Todo.RequestDtos;

public class CreateTodoRequestDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    
    public bool Completed { get; set; } = false;
    public int CategoryId { get; set; }
    public string UserId { get; set; }
}