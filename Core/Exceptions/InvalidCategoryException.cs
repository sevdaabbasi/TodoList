namespace Core.Exceptions;

public class InvalidCategoryException : Exception
{
    public InvalidCategoryException(int id)
        : base($"Category with ID {id} is invalid.")
    {
    }
}
