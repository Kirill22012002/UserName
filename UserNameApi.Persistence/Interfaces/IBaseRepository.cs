using UserNameApi.Models.DbModels;

namespace UserNameApi.Persistence.Interfaces;

public interface IBaseRepository<T> where T : class, IEntity
{
    Task<List<T>> GetAllAsync();
    Task<T> GetAsync(string id);
    Task<T> AddAsync(T entity);
    Task<T> UpdateAsync(T entity);
    Task<T> DeleteAsync(string id);
}
