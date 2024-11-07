using Core.Repository;
using TodoList.Models.Models;
using TodoList.Repository.Contexts;
using TodoList.Repository.Repositories.Abstracts;

namespace TodoList.Repository.Repositories.Concretes;

public class EfCategoryRepository : EfRepositoryBase<EfCoreDbContext, Category, int>, ICategoryRepository
{
    public EfCategoryRepository(EfCoreDbContext context) : base(context)
    {
        
    }
}
