namespace Core.Exceptions;

public class CategoryNotFoundException : Exception
{
    public CategoryNotFoundException(string id)
        : base($"Category with ID {id} not found.")
    {
    }
}
