using Library.DataAccess.Interfaces;
using Library.DataAccess.Entities;
using Library.DataAccess.EF;
using Microsoft.EntityFrameworkCore;

namespace Library.DataAccess.Repositories
{

    public class BookRepository : Repository<Book>, IRepositoryBook
    {
        private readonly LibraryContext _libraryContext;
        public BookRepository(LibraryContext libraryContext) : base(libraryContext)
        {
            this._libraryContext = libraryContext;
        }

        public async Task<IEnumerable<Book>> GetAllAsync(int page, int pageSize)
        {
            var query = _libraryContext.Set<Book>().Skip((page - 1) * pageSize).Take(pageSize).ToList();



            return query;
        }

        public async Task<IEnumerable<Book>> GetBooksByAuthorId(int authorId)
        {
            return _libraryContext.Books.Include(x => x.Author).Where(a => a.AuthorId == authorId);
        }
    }
}
