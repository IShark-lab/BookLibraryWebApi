using Library.DataAccess.Interfaces;
using Library.DataAccess.Entities;
using Library.DataAccess.EF;
using Microsoft.EntityFrameworkCore;



namespace Library.DataAccess.Repositories
{

    public class BookRepository : Repository<Book>, IRepositoryBook
    {
        public BookRepository(LibraryContext libraryContext) : base(libraryContext)
        {

        }


    }
}
