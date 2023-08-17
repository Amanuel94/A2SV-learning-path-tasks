using AutoMapper;
using BlogApp_CA.Application.Dtos;
using BlogApp_CA.Application.Repositories;
using BlogApp_CA.Domain.Entities;
using MediatR;

public class UpdatePostTitleCommandHandler : PostQueryHandler, IRequestHandler<UpdatePostTitleCommand, int>
{
    public UpdatePostTitleCommandHandler(IPostRepository postRepository, IMapper mapper) : base(postRepository, mapper)
    {
    }


    public async Task<int> Handle(UpdatePostTitleCommand request, CancellationToken cancellationToken)
    {
        var oldPost = await _postRepository.GetAsync(request.postId);
        var newpostDto = new PostDto{Title = request.newTitle, Content = oldPost.Content.Value};
        var newPost = _mapper.Map(newpostDto, oldPost);
        await _postRepository.Update(newPost);
        return newPost.Id;

        
        // var post = _mapper.Map<Post>()
    }
}