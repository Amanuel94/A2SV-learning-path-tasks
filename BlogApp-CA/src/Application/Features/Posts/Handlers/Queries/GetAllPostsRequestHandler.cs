
using AutoMapper;
using BlogApp_CA.Application.Dtos;
using BlogApp_CA.Application.Repositories;
using MediatR;

namespace BlogApp_CA.Application.Features.Posts;
public class GetAllPostsRequestHandler : IRequestHandler<GetAllPostsRequest, List<PostDto>>{


    private readonly IPostRepository _postRepository;
    private readonly IMapper _mapper;
    public GetAllPostsRequestHandler(IPostRepository postRepository, IMapper mapper)
    {
        
        _postRepository = postRepository;
        _mapper = mapper;

    }

    public async Task<List<PostDto>> Handle(GetAllPostsRequest request, CancellationToken cancellationToken)
    {
        
        var posts = await _postRepository.GetAllAsync();
        return _mapper.Map<List<PostDto>>(posts);
    }

}