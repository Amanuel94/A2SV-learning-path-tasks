namespace BlogApp_CA.Application.Repositories;

public interface IGenericRepository<T>{

    public abstract  Task<T> GetAsync(int Id);
    public abstract Task<IReadOnlyList<T>> GetAllAsync();
    public abstract Task<T> Add(T record);
    public abstract Task<T> Remove(T record);

    public abstract Task<T> Update(T record);
    

}