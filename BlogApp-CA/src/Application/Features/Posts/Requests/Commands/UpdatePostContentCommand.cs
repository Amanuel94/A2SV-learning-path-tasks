using MediatR;

public class UpdatePostContentCommand: IRequest<int>{

    public  readonly int postId;
    public readonly string newContent;
    public UpdatePostContentCommand(int postId, string newContent)
    {   
        this.postId   = postId;
        this.newContent = newContent;
    }

}