using BloggingApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text;
namespace BloggingApp.Controllers;

[Route("/api/[controller]")]
[ApiController]
public class PostsController:ControllerBase{
    public ApiDbContext _dbContext;
    public PostsController(ApiDbContext dbContext){
        _dbContext = dbContext;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllPostsAsync(){
        List<Post> AllPosts = await _dbContext.Posts.ToListAsync();
        return Ok(AllPosts);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPostWithIdApi(int id)
    {
        var Match = await GetPostAsync(id);
        if(Match is null){
            return NotFound();
        }
        return Ok(Match);
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreatePostAsync(string Title, string Content)
    {
        if(string.IsNullOrEmpty(Title) || string.IsNullOrEmpty(Title))
            return BadRequest("Input can not be empty");

        var newPost = new Post{
            Title = Title,
            Content = Content
        };
        _dbContext.Posts.Add(newPost);
        await _dbContext.SaveChangesAsync();
        return CreatedAtAction(nameof(GetPostWithIdApi), new {id = newPost.PostId}, newPost);
    }

    [HttpPatch("editTitle")]
    public  async Task<IActionResult> ChangePostTitleAsync(int PostId, string NewTitle){
        NewTitle = NewTitle.Trim();
        if(string.IsNullOrEmpty(NewTitle)){
            return BadRequest("input can not be empty");
        }
        Post? Match  = await GetPostAsync(PostId);
        if(Match is null){
            return  BadRequest("nonexistent post id");
        }
        Match.Title = NewTitle;
        await _dbContext.SaveChangesAsync();
        return Ok();
    }

    [HttpPatch("editContent")]
    public  async Task<IActionResult> ChangePostContentAsync(int PostId, string NewContent){
        NewContent = NewContent.Trim();
        if(string.IsNullOrEmpty(NewContent)){
            return BadRequest("input can not be empty");
        }

        Post? Match  = await GetPostAsync(PostId);
        if(Match is null){
            return  BadRequest("nonexistent post id");
        }
        else{
            Match.Content = NewContent;
        }
        await _dbContext.SaveChangesAsync();
        return Ok();
    }

    [HttpDelete("deletePost")]
    public  async Task<IActionResult> DeletePostAsync(int PostId){
        var Match = await GetPostAsync(PostId);
        if(Match is null){
            return BadRequest("nonexistent post id");
        }
        _dbContext.Posts.Remove(Match);
        _dbContext.SaveChanges();
        return Ok();
        
    }


    internal async Task<Post?> GetPostAsync(int PostId){
        return await _dbContext.Posts.FindAsync(PostId);
    }



}