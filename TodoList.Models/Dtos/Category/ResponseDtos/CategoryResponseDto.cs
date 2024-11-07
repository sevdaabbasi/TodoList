namespace TodoList.Models.Dtos.Category.ResponseDtos;

public class CategoryResponseDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime CreatedTime { get; set; }
    public DateTime UpdatedTime { get; set; }
}