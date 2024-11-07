using Core.Entities;

namespace TodoList.Models.Models;

public enum Priority
{
    Low,
    Medium,
    High
}

public class Todo : Entity<int>
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public bool Completed { get; set; } = false;
    public int CategoryId { get; set; }
    public string UserId { get; set; }
    public Category Category { get; set; }
    public User User { get; set; }
}
