using MediatR;
using BlogApp_CA.Application.Dtos;

namespace BlogApp_CA.Application.Features.Comments;

public class GetAllCommentsRequest: IRequest<List<CommentDto>>{
    public int PostId{get;}
    public int CommentId { get; internal set; }


    public GetAllCommentsRequest(int postId)
    {
        PostId = postId;
    }
}