namespace BlogApp_CA.Domain.Exceptions;

public class InvalidPostContentException : Exception
{
    public InvalidPostContentException(string Message)
        : base($"Error 1003: {Message}")
    {
    }
}
