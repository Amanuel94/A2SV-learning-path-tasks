namespace BlogApp_CA.Domain.Exceptions;

public class CommentNotFoundException : Exception
{
    public CommentNotFoundException(string Message)
        : base($"Error 002: {Message}")
    {
    }
}
