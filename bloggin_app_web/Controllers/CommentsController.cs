using BloggingApp.Models;
using BloggingApp.Mapping;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text;
using AutoMapper.QueryableExtensions;

namespace BloggingApp.Controllers;

[Route("/api/Posts/{postId}/[controller]")]
[ApiController]
public class CommentsController:ControllerBase{
    public ApiDbContext _dbContext;
    public CommentsController(ApiDbContext dbContext){
        _dbContext = dbContext;
    }

    [HttpGet]
    public async Task<IActionResult> GetComments(int postId)
    {
        var post = await new PostsController(_dbContext).GetPostAsync(postId);

        if (post == null)
        {
            return NotFound("Nonexistent post id");
        }

        // use automapper to create Dtos and avoid circular reference
        
        List<CommentDto> comments = await _dbContext.Comments
                                            .Where(t => t.PostId == postId)
                                            .ProjectTo<CommentDto>(MapperConfig.Mapper.ConfigurationProvider)
                                            .ToListAsync();


        return Ok(comments);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCommentWithIdApi(int postId, int id)
    {
        var Match = await GetCommentAsync(postId, id);
        if(Match is null){
            return NotFound();
        }
        return Ok(MapperConfig.Mapper.Map<CommentDto>(Match));
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreatePostAsync(int postId, string Content)
    {
        if(string.IsNullOrEmpty(Content))
            return BadRequest("Input can not be empty");

        var newComment = new Comment{
            PostId = postId,
            Text = Content
        };
        _dbContext.Comments.Add(newComment);
        await _dbContext.SaveChangesAsync();
        return CreatedAtAction(nameof(GetCommentWithIdApi), new {id = newComment.CommentId}, newComment);
    }

    [HttpPatch("editContent")]
    public  async Task<IActionResult> ChangeCommentContentAsync(int postId, int commentId, string NewContent){
        NewContent = NewContent.Trim();
        if(string.IsNullOrEmpty(NewContent)){
            return BadRequest("input can not be empty");
        }
        var Match  = await GetCommentAsync(postId, commentId);
        if(Match is null){
            return  BadRequest("nonexistent comment id");
        }
        Match.Text = NewContent;
        await _dbContext.SaveChangesAsync();
        return Ok();
    }

    [HttpDelete("delete")]
    public  async Task<IActionResult> DeleteCommentAsync(int postId, int commentId){
        var Match = await GetCommentAsync(postId, commentId);
        if(Match is null){
            return BadRequest("nonexistent comment id");
        }
        _dbContext.Comments.Remove(Match);
        _dbContext.SaveChanges();
        return Ok();
        
    }


    internal async Task<Comment?> GetCommentAsync(int CommentId, int postId){
        return await _dbContext.Comments.FirstOrDefaultAsync(t=>t.PostId == postId && t.CommentId == CommentId);
    }



}