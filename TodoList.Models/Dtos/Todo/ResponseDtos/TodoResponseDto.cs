namespace TodoList.Models.Dtos.Todo.ResponseDtos;

public sealed record TodoResponseDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public bool Completed { get; set; } 
    public int CategoryId { get; set; }
    public string UserId { get; set; }
    public DateTime CreatedTime { get; set; }
    public DateTime UpdatedTime { get; set; }
}