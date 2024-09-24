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

    public interface IRepositoryBook : IRepository<Book> 
    {
        Task<IEnumerable<Book>> GetBooksByAuthorId(int authorId);
        Task<IEnumerable<Book>> GetAllAsync(int page, int pageSize);
    }
    public interface IRepositoryAuthor : IRepository<Author> 
    {
        Task<Author> GetAuthorByBook(int bookId);
    }
    public interface IRepositoryBorrower : IRepository<Borrower> 
    { 
        
    }
    public interface IRepositoryLoan : IRepository<Loan> 
    {
        Task<IEnumerable<Book>> GetBooksByBorrowerId(int borrowerId);
    }

}
