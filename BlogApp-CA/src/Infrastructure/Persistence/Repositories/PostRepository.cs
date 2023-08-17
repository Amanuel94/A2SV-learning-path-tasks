using BlogApp_CA.Application.Repositories;
using BlogApp_CA.Domain.Entities;

namespace BlogApp_CA.Infrastructure.Persistence.Repositories;

public class PostRepository : GenericRepository<Post>, IPostRepository
{
    public PostRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    

}