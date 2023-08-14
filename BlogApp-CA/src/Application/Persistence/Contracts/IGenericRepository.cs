namespace BlogApp_CA.Application.Repositories;

public interface IGenericRepository<T>{

    public Task<T> GetAsync(int Id);
    public Task<IReadOnlyList<T>> GetAllAsync();

    public Task<T> Add(T record);
    public Task<T> Remove(T record);
    

}