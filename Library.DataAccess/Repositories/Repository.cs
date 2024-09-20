using Library.DataAccess.EF;
using Library.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataAccess.Repositories
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected readonly LibraryContext _context;
        public Repository(LibraryContext context)
        {
            this._context = context;
        }

        public virtual async Task CreateAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(int id)
        {
            var entity = await _context.Set<T>().FindAsync(id);
            if (entity != null)
            {
                _context.Set<T>().Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return _context.Set<T>();
        }

        public virtual async Task<T> GetAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public virtual async Task UpdateAsync(int id, T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
