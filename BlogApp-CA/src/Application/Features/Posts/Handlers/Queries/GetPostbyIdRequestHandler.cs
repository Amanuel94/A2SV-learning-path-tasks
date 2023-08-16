using MediatR;
using BlogApp_CA.Application.Dtos;
using BlogApp_CA.Application.Repositories;
using BlogApp_CA.Domain.Exceptions;
using AutoMapper;

public class GetPostByIdRequestHandler: IRequestHandler<GetPostByIdRequest, PostDto>{
     
    private readonly IPostRepository _postRepository;
    private readonly IMapper _mapper;
    public GetPostByIdRequestHandler(IPostRepository postRepository, IMapper mapper)
    {
        
        _postRepository = postRepository;
        _mapper = mapper;

    }



    public async Task<PostDto> Handle(GetPostByIdRequest request, CancellationToken cancellationToken)
    {
        
        var post = await _postRepository.GetAsync(request.Id);       
        return _mapper.Map<PostDto>(post);
        
    }

}