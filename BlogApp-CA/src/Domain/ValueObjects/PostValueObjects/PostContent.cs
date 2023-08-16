using BlogApp_CA.Domain.Exceptions;
namespace BlogApp_CA.Domain.ValueObjects;

public sealed class PostContent : ValueObject
{

    public string Value{get; init;}
    private static readonly int _maxLength = 2000;
    private PostContent(string val){
        Value = val;
    }
    public override IEnumerable<object> GetAtomicObjects()
    {
        yield return Value;
    }

    public static PostContent? Create(string Content){
        if(string.IsNullOrWhiteSpace(Content)){
            throw new InvalidPostContentException("Content can not be null or white space.");
        }
        if(_maxLength < Content.Length){
            throw new InvalidPostContentException($"Content can not longer than {PostContent._maxLength} characters.");
        }

        return new PostContent(Content);
    }

}