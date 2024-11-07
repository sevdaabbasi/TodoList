using Core.Repository;
using TodoList.Models.Models;
using TodoList.Repository.Contexts;
using TodoList.Repository.Repositories.Abstracts;

namespace TodoList.Repository.Repositories.Concretes;

public class EfTodoRepository : EfRepositoryBase<EfCoreDbContext, Todo, int>, ITodoRepository
{
    public EfTodoRepository(EfCoreDbContext context) : base(context)
    {

    }
}