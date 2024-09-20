using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.DataAccess.Entities;
using Library.DataAccess.Repositories;
using Library.Services.Interaces;
using Library.Domain.Models;
using Library.DataAccess.Interfaces;
using Library.Services.Services;


namespace Library.Services.Repositories
{
    public class BookServices : BaseService<BookDto, Book>, IServiceBook
    {
        public BookServices(IRepositoryBook bookRepository, IMapper<BookDto, Book> bookMapper) : base(bookRepository, bookMapper) { }

        public async Task<IEnumerable<BookDto>> GetAllOrderByTitle()
        {

            var bookDtos = await GetAllAsync();
            bookDtos = bookDtos.OrderBy(x => x.Title);
            return bookDtos;
        }

        public async Task<IEnumerable<BookDto>> GetAllOrderByReleaseDate()
        {
            var bookDtos = await GetAllAsync();
            bookDtos = bookDtos.OrderBy(x => x.PublicationDate);
            return bookDtos;
        }





    }


}
