using BlogApp_CA.Domain.Entities;
namespace BlogApp_CA.Application.Repositories;

public interface ICommentRepository: IGenericRepository<Comment>{

    public Task<Comment> UpdateText(int Id, string NewText);
    public Task<IReadOnlyList<Comment>> GetCommentsOnPost(int PostId);

}