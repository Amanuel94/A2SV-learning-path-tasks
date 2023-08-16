using BlogApp_CA.Domain.Entities;
namespace BlogApp_CA.Application.Repositories;

public interface ICommentRepository: IGenericRepository<Comment>{

    public Task<Comment> UpdateText(int postId, int Id, string NewText);

    public abstract Task<Comment> GetAsync(int PostId, int Id);
    public abstract Task<IReadOnlyList<Comment>> GetAllAsync(int PostId);
    public abstract Task<Comment> Add(int PostId, Comment record);
    public abstract Task<Comment> Remove(int PostId, Comment record);

}