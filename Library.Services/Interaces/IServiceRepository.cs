using Library.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    public interface IServiceBook : IServiceRepository<BookDto>, IServiceOrder<BookDto> { }
    public interface IServiceAuthor : IServiceRepository<AuthorDto> 
    {
        Task<AuthorDto> GetAuthorByBookAsync(int bookId);
    }

}
