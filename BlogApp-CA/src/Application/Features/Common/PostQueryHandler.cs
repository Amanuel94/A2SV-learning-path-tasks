using AutoMapper;
using BlogApp_CA.Application.Repositories;

public class PostQueryHandler{
    protected readonly IPostRepository _postRepository;
    protected readonly IMapper _mapper;

    public PostQueryHandler(IPostRepository postRepository, IMapper mapper)
    {
        _postRepository = postRepository;
        _mapper = mapper;
    }
    
}