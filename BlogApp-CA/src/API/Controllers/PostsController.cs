using BlogApp_CA.Application.Dtos;
using BlogApp_CA.Application.Features.Posts;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;


namespace BlogApp_CA.Api.Controllers;

[Route("api/posts")]
[ApiController]
public class PostsController:ControllerBase{
    private IMediator _mediator;

    public PostsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<List<PostDto>>> GetAllPosts(){
        List<PostDto> postDtos = await _mediator.Send(new GetAllPostsRequest());

        return Ok(postDtos);
    }

    [HttpPost]
    [Route("/create")]
    public async Task<ActionResult<PostDto>> CreatePost(PostDto newPost){
        int newPostId = await _mediator.Send(new CreatePostCommand(newPost.Title, newPost.Content));

        return Ok(newPostId);
    }
}