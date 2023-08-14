namespace BlogApp_CA.Domain.Exceptions;

public class InvalidPostTitleException : Exception
{
    public InvalidPostTitleException(string Message)
        : base($"Error 1002: {Message}")
    {
    }
}
