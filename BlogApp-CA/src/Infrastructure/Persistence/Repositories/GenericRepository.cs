using BlogApp_CA.Application.Repositories;
using BlogApp_CA.Domain.Common;
using Microsoft.EntityFrameworkCore;


namespace BlogApp_CA.Infrastructure.Persistence.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseAuditableEntity
{

    protected readonly ApplicationDbContext _dbContext;
    public GenericRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<T> Add(T record)
    {
        await _dbContext.AddAsync(record);
        await _dbContext.SaveChangesAsync();

        return record;
    }

    public async Task<IReadOnlyList<T>> GetAllAsync()
    {
        IReadOnlyList<T> allGenericRecords = await _dbContext.Set<T>().ToListAsync();
        return allGenericRecords;
    }


    public async Task<T> GetAsync(int Id)
    {
        var post = await _dbContext.Set<T>().FirstOrDefaultAsync<T>(t=>t.Id == Id);
        return post;
    }

    public async Task Remove(T record)
    {
        _dbContext.Remove(record);
    }


    public async Task Update(T record)
    {
        _dbContext.Set<T>().Update(record);
        await _dbContext.SaveChangesAsync();

    }

}