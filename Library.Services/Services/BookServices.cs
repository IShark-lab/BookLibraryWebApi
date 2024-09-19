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


namespace Library.Services.Repositories
{
    public class BookServices : IServiceBook
    {
        private readonly IRepositoryBook _bookRepository;
        private readonly IMapper<BookDto, Book> _bookMapper;

        public BookServices(IRepositoryBook bookRepository, IMapper<BookDto, Book> bookMapper) 
        { 
            this._bookRepository = bookRepository;
            this._bookMapper = bookMapper;
        }

        public async Task<IEnumerable<BookDto>> GetAllAsync()
        {
            var books = await _bookRepository.GetAllAsync();
            if (books is null)
            {
                return Enumerable.Empty<BookDto>();
            }
            
            var bookDtos = books.Select(x => _bookMapper.ToDtoWithId(x)).ToList();

            return bookDtos;
        }

        public async Task<BookDto> GetAsync(int id)
        {
            var book = await _bookRepository.GetAsync(id);

            if (book is null)
            {
                return null;
            }

            var bookDto = _bookMapper.ToDtoWithId(book);

            return bookDto;
        }

        public async Task<ServiceResult> CreateAsync(BookDto bookDto)
        {
            try
            {
                var book = _bookMapper.ToEntity(bookDto);

                await _bookRepository.CreateAsync(book);

                return ServiceResult.Success();
            }
            catch (Exception)
            {
                return ServiceResult.Failure("Failed to create book");
            }

        }

        public async Task<ServiceResult> UpdateAsync(int id, BookDto bookDto)
        {
            try
            {
                var book = _bookMapper.ToEntity(bookDto);
                book.Id = id;

                await _bookRepository.UpdateAsync(id, book);
                return ServiceResult.Success();
            }
            catch (Exception)
            {
                return ServiceResult.Failure("Failed to update book");
            }

        }

        public async Task DeleteAsync(int id)
        {
            await _bookRepository.DeleteAsync(id);
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

       



    }


}
