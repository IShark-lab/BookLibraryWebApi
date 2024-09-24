using Library.DataAccess.EF;
using Library.DataAccess.Entities;
using Library.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataAccess.Repositories
{
    public class LoanRepository : Repository<Loan>, IRepositoryLoan
    {
        private readonly LibraryContext _libraryContext;
        public LoanRepository(LibraryContext context) : base(context) 
        {
            this._libraryContext = context;
        }

        public async Task<IEnumerable<Book>> GetBooksByBorrowerId(int borrowerId)
        {
            var borrower = _libraryContext.Loans.Include(x => x.Book).Where(x => x.BorrowerId == borrowerId);
            var books = await borrower.Select(x => x.Book).ToListAsync();
            return books;
        }
    }
}
