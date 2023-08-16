using AutoMapper;
using BlogApp_CA.Application.Dtos;
using BlogApp_CA.Application.Repositories;
using MediatR;

namespace BlogApp_CA.Application.Features.Comments;

public class GetCommentByIdRequestHandler : PostQueryHandler, IRequestHandler<GetCommentByIdRequest, CommentDto>
{
    public GetCommentByIdRequestHandler(IPostRepository postRepository, IMapper mapper):base(postRepository, mapper)
    {
        
    }


    public async Task<CommentDto> Handle(GetCommentByIdRequest request, CancellationToken cancellationToken)
    {
        // implement with an aggregate-root-type repository post, instead of using the comments repository 
        // to maintain transactional consistency
        var post = await _postRepository.GetAsync(request.PostId);
        var comment = post.Comments.FirstOrDefault(t=>t.Id == request.CommentId);
        return _mapper.Map<CommentDto>(comment);  
    }

}