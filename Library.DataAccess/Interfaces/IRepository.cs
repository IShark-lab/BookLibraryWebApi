using Library.DataAccess.Entities;

namespace Library.DataAccess.Interfaces
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetAsync(int id);
        Task CreateAsync(T entity);
        Task UpdateAsync(int id, T entity);
        Task DeleteAsync(int id);
        Task SaveAsync();
    }

    public interface IRepositoryBook : IRepository<Book> { }

    
}
