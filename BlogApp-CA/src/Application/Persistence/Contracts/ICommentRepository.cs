using BlogApp_CA.Domain.Entities;
namespace BlogApp_CA.Application.Repositories;

public interface ICommentRepository: IGenericRepository<Comment>{

    public Task UpdateText(Comment newRecord);
    
    public abstract Task<IReadOnlyList<Comment>> GetAllAsync(int PostId);

}