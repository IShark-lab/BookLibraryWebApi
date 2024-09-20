using Library.DataAccess.EF;
using Library.DataAccess.Entities;
using Library.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;



namespace Library.DataAccess.Repositories
{
    public class AuthorRepository : Repository<Author>, IRepositoryAuthor
    {
        private readonly LibraryContext _libraryContext;
        public AuthorRepository(LibraryContext libraryContext) : base(libraryContext) 
        {
            this._libraryContext = libraryContext;
        }


       

        public async Task<Author> GetAuthorByBook(int bookId)
        {
            var authors = _libraryContext.Author.Include(b => b.Books).Where(a => a.Books.Any(x => x.Id == bookId));

            return authors.First();
        }

        
    }
}
