namespace BlogApp_CA.Domain.Exceptions;

public class InvalidCommentTextException : Exception
{
    public InvalidCommentTextException(string Message)
        : base($"Error 2002: {Message}")
    {
    }
}
