using BlogApp_CA.Application.Repositories;
using BlogApp_CA.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace BlogApp_CA.Infrastructure.Persistence.Repositories;

public class CommentRepository : GenericRepository<Comment>, ICommentRepository
{
    public CommentRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<Domain.Entities.Comment> Add(int PostId, Domain.Entities.Comment record)
    {
        _dbContext.Add(record);
        await _dbContext.SaveChangesAsync();
        return record;
    }

    public async Task<IReadOnlyList<Comment>> GetAllAsync(int PostId)
    {
     var post = await _dbContext.Posts.FirstOrDefaultAsync(t=>t.Id == PostId);
     
     return (IReadOnlyList<Comment>)post.Comments;
    }

    public Comment GetAsync(int PostId, int Id)
    {
        var comment = _dbContext.Comments.First(t=>t.Id == Id);
        return comment;
    }

    public async Task Remove(int PostId, Comment record)
    {
        _dbContext.Comments.Remove(record);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateText(Comment newRecord)
    {
        _dbContext.Update(newRecord);
        await _dbContext.SaveChangesAsync();
    }

}