using FluentValidation;
using BlogApp_CA.Application.Dtos;
using System.Data;
using BlogApp_CA.Application.Repositories;


public class PostDtoValidator : AbstractValidator<PostDto>
{
    private readonly IPostRepository _postRepository;
    public PostDtoValidator(IPostRepository postRepository)
    {
        _postRepository = postRepository;   
        RuleFor(p=>p.Title)
            .NotEmpty().WithMessage("{PropertyName} can not be empty")
            .NotNull();
        // RuleFor(p=>p.id)
        //     .MustAsync(async (id, token)=>{
        //         var post = await _postRepository.GetAsync(id);
        //         return post != null;
        //     });

    }

}