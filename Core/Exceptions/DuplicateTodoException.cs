namespace Core.Exceptions;

public class DuplicateTodoException : Exception
{
    public DuplicateTodoException(string title)
        : base($"A Todo with the title '{title}' already exists.")
    {
    }
}
