using BlogApp_CA.Domain.Entities;
using BlogApp_CA.Domain.ValueObjects;

namespace BlogApp_CA.Application.Repositories;

public interface IPostRepository : IGenericRepository<Post>
{

    // public  Task<Post> Update(int Id, PostTitle NewTitle);
    // public Task<Post> UpdateContent(int Id Post newPost);
    // public Task GetAsync(object id);

}