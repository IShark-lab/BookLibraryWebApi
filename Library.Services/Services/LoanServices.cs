using Library.DataAccess.Entities;
using Library.DataAccess.Interfaces;
using Library.Domain.Models;
using Library.Services.Interaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services.Services
{
    public class LoanServices : BaseService<LoanDto, Loan>, IServiceLoan
    {
        private readonly IRepositoryLoan _repositoryLoan;
        private readonly IMapper<BookDto, Book> _bookMapper;
        public LoanServices(IRepositoryLoan repository, IMapper<LoanDto, Loan> mapper, IMapper<BookDto, Book> bookMapper) : base(repository, mapper)
        {
            this._repositoryLoan = repository;
            this._bookMapper = bookMapper;
        }


        public async Task<IEnumerable<BookDto>> GetBooksByBorrowerId(int borrowerId)
        {
            var books = await _repositoryLoan.GetBooksByBorrowerId(borrowerId);
            if (books == Enumerable.Empty<Book>())
                return null;

            var booksDto = books.Select(x => _bookMapper.ToDtoWithId(x));
            return booksDto;
        }
    }
}
