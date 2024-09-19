using Library.DataAccess.Entities;

namespace Library.DataAccess.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetAsync(int id);
        Task CreateAsync(T entity);
        Task UpdateAsync(int id, T entity);
        Task DeleteAsync(int id);
    }

    public interface IRepositoryBook : IRepository<Book> { }
    public interface IRepositoryAuthor : IRepository<Author> 
    {
        Task<Author> GetAuthorByBook(int bookId);
    }
    
}
