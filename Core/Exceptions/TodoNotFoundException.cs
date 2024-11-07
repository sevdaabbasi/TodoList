namespace Core.Exceptions;

public class TodoNotFoundException : Exception
{
    public TodoNotFoundException(string id)
        : base($"Todo with ID {id} not found.")
    {
    }
}
