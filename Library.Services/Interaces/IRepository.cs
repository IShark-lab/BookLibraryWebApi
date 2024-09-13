using Library.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Services.Repositories;

namespace Library.Services.Interaces
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetAsync(int id);
        Task<ServiceResult> CreateAsync(T entity);
        Task<ServiceResult> UpdateAsync(int id, T entity);
        Task DeleteAsync(int id);
    }

    public interface IRepositoryBooks<T>
    {
        Task<IEnumerable<T>> GetAllOrderByTitle();
        Task<IEnumerable<T>> GetAllOrderByReleaseDate();
        
    }

}
