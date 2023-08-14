using BlogApp_CA.Domain.Entities;
namespace BlogApp_CA.Application.Repositories;

public interface IPostRepository: IGenericRepository<Post>{

    public Task<Post> UpdateTitle(int Id, string NewTitle);
    public Task<Post> UpdateContent(int Id, string NewContent);

}