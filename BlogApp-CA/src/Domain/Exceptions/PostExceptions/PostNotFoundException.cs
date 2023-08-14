namespace BlogApp_CA.Domain.Exceptions;

public class PostNotFoundException : Exception
{
    public PostNotFoundException(string Message)
        : base($"Error 001: {Message}")
    {
    }
}
