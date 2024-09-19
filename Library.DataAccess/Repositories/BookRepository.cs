using Library.DataAccess.Interfaces;
using Library.DataAccess.Entities;
using Library.DataAccess.EF;
using Microsoft.EntityFrameworkCore;



namespace Library.DataAccess.Repositories
{
    public class BookRepository : IRepositoryBook
    {
        private readonly LibraryContext _libraryContext;   

        public BookRepository(LibraryContext libraryContext)
        {
            this._libraryContext = libraryContext;
        }

        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            return _libraryContext.Books;
        }

        public async Task<Book> GetAsync(int id)
        {
            return await _libraryContext.Books.FindAsync(id);
        }

        public async Task CreateAsync(Book book)
        {
            await _libraryContext.Books.AddAsync(book);
            await _libraryContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, Book book)
        {
            _libraryContext.Entry(book).State = EntityState.Modified;
            await _libraryContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            Book? book = await _libraryContext.Books.FindAsync(id);
            if (book != null) 
            {
                _libraryContext.Books.Remove(book);
            }
            await _libraryContext.SaveChangesAsync();
        }


    }
}
