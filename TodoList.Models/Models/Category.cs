using Core.Entities;

namespace TodoList.Models.Models;

public class Category : Entity<int>
{
    public string Name { get; set; }
    public List<Todo> Todos { get; set; }
}
