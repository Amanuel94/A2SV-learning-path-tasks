using MediatR;
using BlogApp_CA.Application.Dtos;

public class GetPostByIdRequest: IRequest<PostDto>{
     private int _id {get; set;}
     public int Id{get{return _id;}}
     public GetPostByIdRequest(int postId)
     {
        _id = postId;
     }

    
}