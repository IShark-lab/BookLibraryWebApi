using Library.Services.Repositories;
using Library.Domain.Models;


namespace Library.Services.Interaces
{
    public interface IServiceRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetAsync(int id);
        Task<ServiceResult> CreateAsync(T entity);
        Task<ServiceResult> UpdateAsync(int id, T entity);
        Task DeleteAsync(int id);
    }

    public interface IServiceOrder<T>
    {
        Task<IEnumerable<T>> GetAllOrderByTitle();
        Task<IEnumerable<T>> GetAllOrderByReleaseDate();
        
    }
    public interface IServiceBook : IServiceRepository<BookDto>, IServiceOrder<BookDto> 
    { 
        Task<IEnumerable<BookDto>> GetBooksByAuthorId(int authorId);
        Task<IEnumerable<BookDto>> GetAllAsync(string order);
        Task<IEnumerable<BookDto>> GetAllAsync(string order,int page, int pageSize);
    }
    public interface IServiceAuthor : IServiceRepository<AuthorDto> 
    {
        Task<AuthorDto> GetAuthorByBookAsync(int bookId);
    }
    public interface IServiceBorrower : IServiceRepository<BorrowerDto> { }
    public interface IServiceLoan : IServiceRepository<LoanDto> 
    {
        Task<IEnumerable<BookDto>> GetBooksByBorrowerId(int borrowerId);
    }

}
