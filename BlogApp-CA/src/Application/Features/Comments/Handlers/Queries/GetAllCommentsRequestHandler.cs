using AutoMapper;
using BlogApp_CA.Application.Dtos;
using BlogApp_CA.Application.Repositories;
using MediatR;

namespace BlogApp_CA.Application.Features.Comments;

public class GetAllCommentsRequestHandler : PostQueryHandler, IRequestHandler<GetAllCommentsRequest, List<CommentDto>>
{
    public GetAllCommentsRequestHandler(IPostRepository postRepository, IMapper mapper):base(postRepository, mapper){

    }
    public async Task<List<CommentDto>> Handle(GetAllCommentsRequest request, CancellationToken cancellationToken)
    {
        // implement with an aggregate-root-type repository post, instead of using the comments repository 
        // to maintain transactional consistency
        var post = await _postRepository.GetAsync(request.PostId);
        return _mapper.Map<List<CommentDto>>(post.Comments);
       
    }
}