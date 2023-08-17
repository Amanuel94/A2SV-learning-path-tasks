using MediatR;
using BlogApp_CA.Application.Dtos;

public class GetAllPostsRequest: IRequest<List<PostDto>>{

}