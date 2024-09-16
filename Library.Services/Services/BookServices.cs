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

        public BookServices(IRepositoryBook bookRepository) 
        { 
            this._bookRepository = bookRepository;
        }

        public async Task<IEnumerable<BookDTO>> GetAllAsync()
        {
            var books = await _bookRepository.GetAllAsync();
            if (books is null)
            {
                return Enumerable.Empty<BookDTO>();
            }

            var bookDtos = books.Select(book => new BookDTO
            {
                Id = book.Id,
                Title = book.Title,
                Ganre = book.Ganre,
                Author = book.Author,
                ReleasedDate = book.ReleasedDate
            });

            return bookDtos;
        }

        public async Task<BookDTO> GetAsync(int id)
        {
            var book = await _bookRepository.GetAsync(id);

            if (book is null)
            {
                return null;
            }

            var bookDto = new BookDTO
            {
                Id = book.Id,
                Title = book.Title,
                Ganre = book.Ganre,
                Author = book.Author,
                ReleasedDate = book.ReleasedDate
            };

            return bookDto;
        }

        public async Task<ServiceResult> CreateAsync(BookDTO entity)
        {
            try
            {
                var book = new Book
                {
                    Id = entity.Id,
                    Title = entity.Title,
                    Ganre = entity.Ganre,
                    Author = entity.Author,
                    ReleasedDate = entity.ReleasedDate
                };

                await _bookRepository.CreateAsync(book);

                return ServiceResult.Success();
            }
            catch (Exception)
            {
                return ServiceResult.Failure("Failed to create book: {ex.Message}");
            }

        }

        public async Task<ServiceResult> UpdateAsync(int id, BookDTO entity)
        {
            try
            {
                if (id != entity.Id)
                {
                    return ServiceResult.Failure("Id is incorrect");
                }

                var book = new Book
                {
                    Id = entity.Id,
                    Title = entity.Title,
                    Ganre = entity.Ganre,
                    Author = entity.Author,
                    ReleasedDate = entity.ReleasedDate
                };

                await _bookRepository.UpdateAsync(id, book);
                return ServiceResult.Success();
            }
            catch (Exception)
            {
                return ServiceResult.Failure("Failed to update book: {ex.Message}");
            }

        }

        public async Task DeleteAsync(int id)
        {
            await _bookRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<BookDTO>> GetAllOrderByTitle()
        {

            var bookDtos = await GetAllAsync();
            bookDtos = bookDtos.OrderBy(x => x.Title);
            return bookDtos;
        }

        public async Task<IEnumerable<BookDTO>> GetAllOrderByReleaseDate()
        {
            var bookDtos = await GetAllAsync();
            bookDtos = bookDtos.OrderBy(x => x.ReleasedDate);
            return bookDtos;
        }

       



    }


}
