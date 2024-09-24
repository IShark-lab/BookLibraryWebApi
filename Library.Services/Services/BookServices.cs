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
using System.Collections;


namespace Library.Services.Repositories
{
    public class BookServices : BaseService<BookDto, Book>, IServiceBook
    {
        private readonly IRepositoryBook _repositoryBook;
        public BookServices(IRepositoryBook bookRepository, IMapper<BookDto, Book> bookMapper) : base(bookRepository, bookMapper)
        {
            this._repositoryBook = bookRepository;
        }

        public async Task<IEnumerable<BookDto>> GetAllAsync(string order, int page, int pageSize)
        {
            var books = await _repositoryBook.GetAllAsync(page, pageSize);

            IEnumerable<BookDto> booksDto = null;

            var booksQuery = order switch
            {
                "title" => booksDto = books.OrderBy(x => x.Title).Select(x => _mapper.ToDtoWithId(x)),
                "date" => booksDto = books.OrderBy(x => x.PublicationDate).Select(x => _mapper.ToDtoWithId(x)),
                _ => booksDto = books.Select(x => _mapper.ToDtoWithId(x))
            };


            return booksDto;
        }

        public async Task<IEnumerable<BookDto>> GetAllAsync(string order)
        {
            if (order == "title")
            {
                return await GetAllOrderByTitle();
            }
            else if (order == "date")
            {
                return await GetAllOrderByReleaseDate();
            }
            else
            {
                return await GetAllAsync();
            }

        }


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


        public async Task<IEnumerable<BookDto>> GetBooksByAuthorId(int id)
        {
            var books = await _repositoryBook.GetBooksByAuthorId(id);
            if (books == Enumerable.Empty<BookDto>())
                return null;
            var booksDto = books.Select(x => _mapper.ToDtoWithId(x)).ToList();

            return booksDto;
        }


    }


}
