using BlogApp_CA.Application.Dtos;
using MediatR;

namespace BlogApp_CA.Application.Features.Posts;

public class CreatePostCommand : IRequest<int>
{
    public readonly PostDto PostDTO;
    public CreatePostCommand(string title, string content)
    {
        PostDTO = new PostDto{
            Title = title,
            Content = content
            };
                                
    }

}