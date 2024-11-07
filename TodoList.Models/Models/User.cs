using Microsoft.AspNetCore.Identity;

namespace TodoList.Models.Models;

public class User : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public List<Todo> Todos { get; set; }
}
