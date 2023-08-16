using BlogApp_CA.Domain.Exceptions;
namespace BlogApp_CA.Domain.ValueObjects;

public  sealed class PostTitle : ValueObject
{

    public string Value{get; init;}
    private static readonly int _maxLength = 50;
    private PostTitle(string val){
        Value = val;
    }
    public override IEnumerable<object> GetAtomicObjects()
    {
        yield return Value;
    }

    public static PostTitle? Create(string title){
        if(string.IsNullOrWhiteSpace(title)){
            throw new InvalidPostTitleException("Title can not be null or white space.");
        }
        if(_maxLength < title.Length){
            throw new InvalidPostTitleException($"Title can not longer than {PostTitle._maxLength}.");
        }

        return new PostTitle(title);
    }

}