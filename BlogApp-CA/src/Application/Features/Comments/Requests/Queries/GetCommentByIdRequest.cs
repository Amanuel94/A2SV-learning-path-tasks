using MediatR;
using BlogApp_CA.Application.Dtos;

namespace BlogApp_CA.Application.Features.Comments;

public class GetCommentByIdRequest: IRequest<CommentDto>{
    public int PostId{get;}
    public int CommentId{get;}
    public GetCommentByIdRequest(int postId, int commentId)
    {
        PostId = postId;
        CommentId = commentId;
    }
    
}