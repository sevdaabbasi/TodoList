//using Core.Exceptions;

using Core.Exceptions;
using TodoList.Models.Models;
using TodoList.Repository.Repositories.Abstracts;

namespace TodoList.Service.Rules;

public class CategoryBusinessRules
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryBusinessRules(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public void CategoryShouldExistWhenRequested(int id)
    {
        Category? category = _categoryRepository.Get(x => x.Id == id);
        if (category is null) throw new CategoryNotFoundException("Category not found");
    }
}
