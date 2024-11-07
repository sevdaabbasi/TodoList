using Core.Repository;
using TodoList.Models.Models;

namespace TodoList.Repository.Repositories.Abstracts;

public interface ICategoryRepository : IRepository<Category, int>
{

}