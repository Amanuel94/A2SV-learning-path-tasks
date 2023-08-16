namespace BlogApp_CA.Domain.ValueObjects;

public sealed class CommentText : ValueObject
{

    public string Value{get; init;}
    private static readonly int _maxLength = 200;
    private CommentText(string val){
        Value = val;
    }
    public override IEnumerable<object> GetAtomicObjects()
    {
        yield return Value;
    }

    public static CommentText? Create(string Content){
        if(string.IsNullOrWhiteSpace(Content)){
            throw new InvalidPostContentException("Content can not be null or white space.");
        }
        if(_maxLength < Content.Length){
            throw new InvalidPostContentException($"Content can not longer than {CommentText._maxLength} characters.");
        }

        return new CommentText(Content);
    }

}