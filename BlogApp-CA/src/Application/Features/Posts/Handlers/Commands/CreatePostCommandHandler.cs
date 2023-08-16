using AutoMapper;
using BlogApp_CA.Application.Repositories;
using MediatR;
using BlogApp_CA.Domain.Entities;

namespace BlogApp_CA.Application.Features.Posts;

public class CreatePostCommandHandler :PostQueryHandler, IRequestHandler<CreatePostCommand, int>
{

    public CreatePostCommandHandler(IPostRepository postRepository, IMapper mapper):base(postRepository, mapper)
    {
        
    }
    public async Task<int> Handle(CreatePostCommand request, CancellationToken cancellationToken)
    {
        var newPost = _mapper.Map<Post>(request.PostDTO);
        var record = await _postRepository.Add(newPost);
        return record.Id;        
    }
}