using Library.DataAccess.Interfaces;
using Library.DataAccess.Entities;
using Library.DataAccess.EF;
using Microsoft.EntityFrameworkCore;



namespace Library.DataAccess.Repositories
{
    public class BookRepository : IRepository<Book>
    {
        private BookContext _bookContext = new BookContext();   

        //public BookRepository(BookContext bookContext)
        //{
        //    this._bookContext = bookContext;
        //}

        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            return _bookContext.Books;
        }

        public async Task<Book> GetAsync(int id)
        {
            return await _bookContext.Books.FindAsync(id);
        }

        public async Task CreateAsync(Book book)
        {
            await _bookContext.Books.AddAsync(book);
            await SaveAsync();
        }

        public async Task UpdateAsync(int id, Book book)
        {
           _bookContext.Entry(book).State = EntityState.Modified;
            await SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            Book? book = await _bookContext.Books.FindAsync(id);
            if (book != null) 
            {
                _bookContext.Books.Remove(book);
            }
            await SaveAsync();
        }
        public async Task SaveAsync()
        {
            await _bookContext.SaveChangesAsync();
        }

    }
}
