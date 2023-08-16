using MediatR;

public class UpdatePostTitleCommand : IRequest<int>
{

    public  readonly int postId;
    public readonly string newTitle;
    public UpdatePostTitleCommand(int postId, string newTitle)
    {   
        this.postId   = postId;
        this.newTitle = newTitle;
    }

}