using Core.Repository;
using TodoList.Models.Models;

namespace TodoList.Repository.Repositories.Abstracts;

public interface ITodoRepository : IRepository<Todo, int>
{

}
