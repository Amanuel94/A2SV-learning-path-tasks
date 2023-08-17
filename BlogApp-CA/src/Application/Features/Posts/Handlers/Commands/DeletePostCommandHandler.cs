using AutoMapper;
using BlogApp_CA.Application.Repositories;
using MediatR;

namespace BlogApp_CA.Application.Features.Posts;

public class DeletePostCommandHandler :PostQueryHandler, IRequestHandler<DeletePostCommand>
{

    public DeletePostCommandHandler(IPostRepository postRepository, IMapper mapper):base(postRepository, mapper)
    {
        
    }

    public async Task Handle(DeletePostCommand request, CancellationToken cancellationToken){

        var postToDelete = await _postRepository.GetAsync(request.Id);
        if(postToDelete != null){
           await _postRepository.Remove(postToDelete);
        }
    }
}