using AutoMapper;
using BlogApp_CA.Application.Dtos;
using BlogApp_CA.Application.Repositories;
using BlogApp_CA.Domain.Entities;
using MediatR;

public class UpdatePostContentCommandHandler : PostQueryHandler, IRequestHandler<UpdatePostContentCommand, int>
{
    public UpdatePostContentCommandHandler(IPostRepository postRepository, IMapper mapper) : base(postRepository, mapper)
    {
    }


    public async Task<int> Handle(UpdatePostContentCommand request, CancellationToken cancellationToken)
    {
        
        var oldPost = await _postRepository.GetAsync(request.postId);
        var newpostDto = new PostDto{Content = request.newContent, Title = oldPost.Title.Value};
        PostDtoValidator validator = new PostDtoValidator(_postRepository);
        
        // the validation is done with primitive obsession using value objects, but a validation with
        // fluent validation is done to demonstrate another way

        var validationResult  = await validator.ValidateAsync(newpostDto);
        if(!validationResult.IsValid){
            throw new Exception(validationResult.Errors.ToString());
        }
        var newPost = _mapper.Map(newpostDto, oldPost);
        await _postRepository.Update(newPost);
        return newPost.Id;
        
    }
}