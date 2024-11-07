//using Core.Exceptions;

using Core.Exceptions;
using TodoList.Models.Models;
using TodoList.Repository.Repositories.Abstracts;

namespace TodoList.Service.Rules;

public class TodoBusinessRules
{
    private readonly ITodoRepository _todoRepository;

    public TodoBusinessRules(ITodoRepository todoRepository)
    {
        _todoRepository = todoRepository;
    }

    public void TodoShouldExistWhenRequested(int id)
    {
        Todo? todo = _todoRepository.Get(x => x.Id == id);
      
       if (todo is null) throw new TodoNotFoundException("Todo not Found");
    }
}
