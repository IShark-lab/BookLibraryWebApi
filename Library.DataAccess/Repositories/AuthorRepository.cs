using Library.DataAccess.EF;
using Library.DataAccess.Entities;
using Library.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;



namespace Library.DataAccess.Repositories
{
    public class AuthorRepository : IRepositoryAuthor
    {
        private readonly LibraryContext _libraryContext;

        public AuthorRepository(LibraryContext libraryContext)
        {
            this._libraryContext = libraryContext;
        }

        public async Task CreateAsync(Author entity)
        {
            await _libraryContext.Author.AddAsync(entity);
            await _libraryContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var author = await _libraryContext.Author.FindAsync(id);
            if (author != null)
                _libraryContext.Author.Remove(author);
            await _libraryContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Author>> GetAllAsync()
        {
            IEnumerable<Author> authors = _libraryContext.Author;
            return authors;
        }

        public async Task<Author> GetAsync(int id)
        {
            return await _libraryContext.Author.FindAsync(id);
        }

        public async Task<Author> GetAuthorByBook(int bookId)
        {
            var authors = _libraryContext.Author.Include(b => b.Books).Where(a => a.Books.Any(x => x.Id == bookId));

            return authors.First();
        }

        public async Task UpdateAsync(int id, Author author)
        {
            _libraryContext.Author.Entry(author).State = EntityState.Modified;
            await _libraryContext.SaveChangesAsync();
        }
    }
}
